package $CLASSROOT$.service.impl;

import jp.co.gutingjun.common.util.R;
import $CLASSROOT$.entity.$ENTITYNAME$Entity;
import $CLASSROOT$.service.$ENTITYNAME$Service;
import org.springframework.stereotype.Service;
import $CLASSROOT$.vo.$ENTITYNAME$VO;
$HASAGGVO BEGIN$
import $CLASSROOT$.vo.$ENTITYNAME$AggVO;
import jp.co.gutingjun.common.pms.entity.AggVO;
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

  @Override
  public Long save($ENTITYNAME$Entity entity) {
    return EntityUtils.saveEntity(entity);
  }
$HASAGGVO BEGIN$
    @Override
    public AggVO get$ENTITYNAME$AggVOByID(Long id) {
        AggVO aggvo = AggVOUtil.loadAggVOByParent($ENTITYNAME$AggVO.class, id);
        return aggvo;
    }

    @Override
    public Long save($ENTITYNAME$AggVO aggVO) throws Exception{
        Long rtn = AggVOUtil.save(aggVO);
        return rtn;
    }$HASAGGVO END$
$HASBIZKEY BEGIN$
    @Override
    public $ENTITYNAME$Entity[] get$ENTITYNAME$ByBizKey(Long bizKey) {
        List<$ENTITYNAME$Entity> result = EntityUtils.getEntityListByBizKey($ENTITYNAME$Entity.class, bizKey);

        return result == null ? null : result.toArray(new $ENTITYNAME$Entity[0]);
    }$HASBIZKEY END$
}