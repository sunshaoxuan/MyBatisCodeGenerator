package $CLASSROOT$.impl;

import $CLASSROOT$.entity.$ENTITYNAME$Entity;
import $CLASSROOT$.inf.*;
import $CLASSROOT$.vo.*;$HASAGGVO BEGIN$
import $CLASSROOT$.vo.aggvo.*; $HASAGGVO END$
import org.springframework.transaction.annotation.Transactional;
import org.springframework.stereotype.Service;
import jp.co.gutingjun.pms.common.CommonUtils;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;


@Service
public class $ENTITYNAME$ServiceImpl implements I$ENTITYNAME$Service {
  @Override
  public $ENTITYNAME$VO[] getAll$ENTITYNAME$() {
    return Arrays.stream($ENTITYNAME$VO.findAll())
        .collect(Collectors.toList())
        .toArray(new $ENTITYNAME$VO[0]);  
  }

  @Override
  public $ENTITYNAME$VO get$ENTITYNAME$ByID(Long id) {
    return $ENTITYNAME$VO.findByID(id);
  }
$IF HASAGGVO$
  @Override
  public AggVO get$ENTITYNAME$AggVOByID(Long id) {
    $ENTITYNAME$AggVO aggVO = new $ENTITYNAME$AggVO();
    aggVO.loadByParentID(id);
    return aggVO;
  }
  
  @Override
  public AggVO get$ENTITYNAME$AggVOByIDLang(Long id, String lang) {
    $ENTITYNAME$AggVO aggVO = new $ENTITYNAME$AggVO();
    aggVO.putLang(lang);
    aggVO.loadByParentID(id);
    return aggVO;
  }

  @Transactional(rollbackFor=Exception.class)
  @Override
  public $ENTITYNAME$AggVO save($ENTITYNAME$AggVO aggVO) throws Exception{
    aggVO.save(null);

    $ENTITYNAME$AggVO newAggVO = new $ENTITYNAME$AggVO();
    newAggVO.loadByParentID(aggVO.pickParentID());
    return newAggVO;
  }

  @Transactional(rollbackFor=Exception.class)
  @Override
  public Integer delete($ENTITYNAME$AggVO aggVO) throws Exception {
    return aggVO.delete(null);
  }
$ELSE$
  @Transactional(rollbackFor=Exception.class)
  @Override
  public Long save($ENTITYNAME$VO vo) throws Exception {
    return vo.save(null);
  }

  @Transactional(rollbackFor=Exception.class)
  @Override
  public Integer delete($ENTITYNAME$VO vo) throws Exception{
    return vo.delete(null);
  }$END IF$ $HASBIZKEY BEGIN$ 
    @Override
    public $ENTITYNAME$VO[] get$ENTITYNAME$ByBizKey($IF BIZKEYCONTAINVARCHAR$String $ELSE$ Long $END IF$ bizKey) {
        return $ENTITYNAME$VO.findByBizKey(bizKey).toArray(new $ENTITYNAME$VO[0]);
    }
$HASBIZKEY END$
}