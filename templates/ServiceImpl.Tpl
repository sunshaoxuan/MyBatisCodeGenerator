package $CLASSROOT$.impl;

import $CLASSROOT$.entity.$ENTITYNAME$Entity;
import $CLASSROOT$.inf.*;
import $CLASSROOT$.vo.*;$HASAGGVO BEGIN$
import $CLASSROOT$.vo.aggvo.*; $HASAGGVO END$
import org.springframework.transaction.annotation.Transactional;
import org.springframework.stereotype.Service;
import $CLASSROOT$.common.CommonUtils;

import java.util.ArrayList;
import java.util.List;


@Service
public class $ENTITYNAME$ServiceImpl implements I$ENTITYNAME$Service {
  @Override
  public $ENTITYNAME$VO[] getAll$ENTITYNAME$() {
    List<$ENTITYNAME$Entity> entityList = CommonUtils.getAllEntityList($ENTITYNAME$Entity.class);
    if (entityList != null && entityList.size() > 0) {
      List<$ENTITYNAME$VO> $LOWER_ENTITYNAME$VOList = new ArrayList<$ENTITYNAME$VO>();
      for ($ENTITYNAME$Entity entity : entityList) {
        $ENTITYNAME$VO newVO = new $ENTITYNAME$VO();
        newVO.set$ENTITYNAME$Entity(entity);
        $LOWER_ENTITYNAME$VOList.add(newVO);
      }
      if ($LOWER_ENTITYNAME$VOList.size() > 0) {
        return $LOWER_ENTITYNAME$VOList.toArray(new $ENTITYNAME$VO[0]);
      }
    }
    return null;
  }

  @Override
  public $ENTITYNAME$VO get$ENTITYNAME$ByID(Long id) {
    return new $ENTITYNAME$VO(id);
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
    aggVO.save();

    $ENTITYNAME$AggVO newAggVO = new $ENTITYNAME$AggVO();
    newAggVO.loadByParentID(aggVO.pickParentID());
    return newAggVO;
  }
$ELSE$
  @Transactional(rollbackFor=Exception.class)
  @Override
  public Long save($ENTITYNAME$VO vo) throws Exception {
    return vo.save();
  }$END IF$ $HASBIZKEY BEGIN$ $IF BIZKEYCONTAINVARCHAR$
    @Override
    public $ENTITYNAME$VO[] get$ENTITYNAME$ByBizKey(String bizKey) {
        List<$ENTITYNAME$VO> rtn = new ArrayList<$ENTITYNAME$VO>();
        List<$ENTITYNAME$Entity> result = CommonUtils.getEntityListByBizKey($ENTITYNAME$Entity.class, bizKey);
        if(result != null && result.size() > 0){
          for ($ENTITYNAME$Entity entity : result) {
              $ENTITYNAME$VO newVO = new $ENTITYNAME$VO();
              newVO.set$ENTITYNAME$Entity(entity);
              rtn.add(newVO);
          }
        }
        return result == null ? null : rtn.toArray(new $ENTITYNAME$VO[0]); 
    }$ELSE$
  @Override
  public $ENTITYNAME$VO[] get$ENTITYNAME$ByBizKey(Long bizKey) {
    List<$ENTITYNAME$VO> rtn = new ArrayList<$ENTITYNAME$VO>();
    List<$ENTITYNAME$Entity> result = CommonUtils.getEntityListByBizKey($ENTITYNAME$Entity.class, bizKey);
    if(result != null && result.size() > 0){
        for ($ENTITYNAME$Entity entity : result) {
            $ENTITYNAME$VO newVO = new $ENTITYNAME$VO();
            newVO.set$ENTITYNAME$Entity(entity);
            rtn.add(newVO);
        }
    }
    return result == null ? null : rtn.toArray(new $ENTITYNAME$VO[0]); 
  }$END IF$ $HASBIZKEY END$

  @Transactional(rollbackFor=Exception.class)
  @Override
  public Integer delete($ENTITYNAME$VO vo) throws Exception{
    return vo.delete();
  }
}