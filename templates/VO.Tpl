package $CLASSROOT$.vo;

import $CLASSROOT$.entity.$ENTITYNAME$Entity;$HASMULTILANGPROPERTY BEGIN$
import $CLASSROOT$.entity.$ENTITYNAME$ResEntity;$HASMULTILANGPROPERTY END$
import $CLASSROOT$.service.impl.EntityUtils;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.io.Serializable;
import java.util.List;

@NoArgsConstructor
public class $ENTITYNAME$VO implements Serializable{
  private $ENTITYNAME$Entity $LOWER_ENTITYNAME$Entity;$HASMULTILANGPROPERTY BEGIN$
  private $ENTITYNAME$ResEntity[] $LOWER_ENTITYNAME$ResEntity;$HASMULTILANGPROPERTY END$

  public $ENTITYNAME$Entity get$ENTITYNAME$Entity() {
    return $LOWER_ENTITYNAME$Entity;
  }
  
  public Long getId() {
    if (get$ENTITYNAME$Entity() != null) {
      return get$ENTITYNAME$Entity().getId();
    }
    return 0L;
  }

  public void set$ENTITYNAME$Entity($ENTITYNAME$Entity $LOWER_ENTITYNAME$Entity) {
    this.$LOWER_ENTITYNAME$Entity = $LOWER_ENTITYNAME$Entity;$HASMULTILANGPROPERTY BEGIN$
    if($LOWER_ENTITYNAME$Entity != null){
      loadResByID($LOWER_ENTITYNAME$Entity.getId());
    }$HASMULTILANGPROPERTY END$
  }$HASMULTILANGPROPERTY BEGIN$

  public $ENTITYNAME$ResEntity[] get$ENTITYNAME$ResEntity() {
    return $LOWER_ENTITYNAME$ResEntity;
  }

  public void set$ENTITYNAME$ResEntity($ENTITYNAME$ResEntity[] $LOWER_ENTITYNAME$ResEntity) {
    this.$LOWER_ENTITYNAME$ResEntity = $LOWER_ENTITYNAME$ResEntity;
  }$HASMULTILANGPROPERTY END$

  public $ENTITYNAME$VO(Long id) {
    set$ENTITYNAME$Entity(EntityUtils.getEntityByPK($ENTITYNAME$Entity.class, id));$HASMULTILANGPROPERTY BEGIN$
    loadResByID(id);$HASMULTILANGPROPERTY END$
  }
  
  public $ENTITYNAME$VO(Long id, String lang){
    set$ENTITYNAME$Entity(EntityUtils.getEntityByPK($ENTITYNAME$Entity.class, id));$HASMULTILANGPROPERTY BEGIN$
    loadResByID(id, lang);$HASMULTILANGPROPERTY END$
  }$HASMULTILANGPROPERTY BEGIN$

  private void loadResByID(Long id) {
    List<$ENTITYNAME$ResEntity> resEntities =
        EntityUtils.getEntityListByBizKey($ENTITYNAME$ResEntity.class, id);
    if (resEntities != null) {
      set$ENTITYNAME$ResEntity(resEntities.toArray(new $ENTITYNAME$ResEntity[0]));
    }
  }

  private void loadResByID(Long id, String lang) {
    $ENTITYNAME$ResEntity resEntity = EntityUtils.getResEntityByPK($ENTITYNAME$ResEntity.class, id, lang);
    if (resEntity != null) {
      set$ENTITYNAME$ResEntity(new $ENTITYNAME$ResEntity[] {resEntity});
    }
  }$HASMULTILANGPROPERTY END$

  public static List<$ENTITYNAME$Entity> getListByBizKey(Long bizKey) {
    return EntityUtils.getEntityListByBizKey($ENTITYNAME$Entity.class, bizKey);
  }
}