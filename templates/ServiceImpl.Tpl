package $CLASSROOT$.service.impl;

import $CLASSROOT$.entity.$ENTITYNAME$Entity;
import $CLASSROOT$.service.$ENTITYNAME$Service;
import org.springframework.stereotype.Service;
import $CLASSROOT$.vo.$ENTITYNAME$VO;
$HASAGGVO BEGIN$
import jp.co.gutingjun.pms.vo.AggVO;
import $CLASSROOT$.vo.$ENTITYNAME$AggVO; $HASAGGVO END$

import java.util.ArrayList;
import java.util.List;


@Service
public class $ENTITYNAME$ServiceImpl implements $ENTITYNAME$Service {
  @Override
  public $ENTITYNAME$VO[] getAll$ENTITYNAME$() {
    List<$ENTITYNAME$Entity> entityList = EntityUtils.getEntityList($ENTITYNAME$Entity.class);
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
        AggVO aggvo = AggVOUtil.loadAggVOByParent($ENTITYNAME$AggVO.class, id);
        return aggvo;
    }

  @Override
  public Long save($ENTITYNAME$AggVO aggVO) throws Exception{
    return aggVO.save();
  }
$ELSE$
  @Override
  public Long save($ENTITYNAME$VO vo) {
    return vo.save();
  }$END IF$
$HASBIZKEY BEGIN$
$IF BIZKEYCONTAINVARCHAR$
    @Override
    public $ENTITYNAME$VO[] get$ENTITYNAME$ByBizKey(String bizKey) {
        List<$ENTITYNAME$VO> rtn = new ArrayList<$ENTITYNAME$VO>();
        List<$ENTITYNAME$Entity> result = EntityUtils.getEntityListByBizKey($ENTITYNAME$Entity.class, bizKey);
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
        List<$ENTITYNAME$Entity> result = EntityUtils.getEntityListByBizKey($ENTITYNAME$Entity.class, bizKey);
        if(result != null && result.size() > 0){
          for ($ENTITYNAME$Entity entity : result) {
              $ENTITYNAME$VO newVO = new $ENTITYNAME$VO();
              newVO.set$ENTITYNAME$Entity(entity);
              rtn.add(newVO);
          }
        }
        return result == null ? null : rtn.toArray(new $ENTITYNAME$VO[0]); 
    }$END IF$ $HASBIZKEY END$
}