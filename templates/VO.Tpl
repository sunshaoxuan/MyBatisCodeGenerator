package $CLASSROOT$.vo;

import $CLASSROOT$.entity.$ENTITYNAME$Entity;$HASMULTILANGPROPERTY BEGIN$
import $CLASSROOT$.entity.$ENTITYNAME$ResEntity;$HASMULTILANGPROPERTY END$
import $CLASSROOT$.service.impl.EntityUtils;
import lombok.NoArgsConstructor;

import java.util.List;

@NoArgsConstructor
public class $ENTITYNAME$VO extends ValueObject{
  private $ENTITYNAME$Entity $LOWER_ENTITYNAME$Entity;$HASMULTILANGPROPERTY BEGIN$
  private $ENTITYNAME$ResEntity[] $LOWER_ENTITYNAME$ResEntity;$HASMULTILANGPROPERTY END$

  public $ENTITYNAME$Entity get$ENTITYNAME$Entity() {
    return $LOWER_ENTITYNAME$Entity;
  }

  @Override
  public Long pickId() {
    if (get$ENTITYNAME$Entity() != null) {
      return get$ENTITYNAME$Entity().getId();
    }
    return 0L;
  }
  
  @Override
  public void putEntity(Object entity) {
    set$ENTITYNAME$Entity(($ENTITYNAME$Entity) entity);
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
    if (id != null && id > 0L) {
      List<$ENTITYNAME$ResEntity> resEntities =
          EntityUtils.getResEntityByPK($ENTITYNAME$ResEntity.class, id);
      if (resEntities != null) {
        set$ENTITYNAME$ResEntity(resEntities.toArray(new $ENTITYNAME$ResEntity[0]));
      }
    }
  }

  
  public void set$ENTITYNAME$Entity($ENTITYNAME$Entity  $LOWER_ENTITYNAME$Entity, String lang) {
    this. $LOWER_ENTITYNAME$Entity =  $LOWER_ENTITYNAME$Entity;
    if( $LOWER_ENTITYNAME$Entity != null){
      loadResByID( $LOWER_ENTITYNAME$Entity.getId(), lang);
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

  @Override
  public Object pickEntity() {
    return get$ENTITYNAME$Entity();
  }

  @Override
  public Object pickRefEntity() {
    return $IF HASMULTILANGPROPERTY$get$ENTITYNAME$ResEntity();$ELSE$null;$END IF$
  }
    
  @Override
  public void putEntity(Object entity, String lang) {
    $IF HASMULTILANGPROPERTY$ set$ENTITYNAME$Entity(($ENTITYNAME$Entity) entity, lang); $ELSE$ $END IF$
  }
}