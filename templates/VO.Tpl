package $CLASSROOT$.vo;

import $CLASSROOT$.entity.$ENTITYNAME$Entity;$HASMULTILANGPROPERTY BEGIN$
import $CLASSROOT$.entity.$ENTITYNAME$ResEntity;$HASMULTILANGPROPERTY END$
import $CLASSROOT$.common.CommonUtils;
import lombok.NoArgsConstructor;
$IF HASMULTILANGPROPERTY$
import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.Collectors; $END IF$
import java.util.List;

@NoArgsConstructor
public class $ENTITYNAME$VO extends ValueObject<$ENTITYNAME$Entity>{
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
  public void putEntity($ENTITYNAME$Entity entity) {
    set$ENTITYNAME$Entity(($ENTITYNAME$Entity) entity);
  }

  /**
   * 用$ENTITYNAME$Entity填充$ENTITYNAME$VO
   * 
   * @param $LOWER_ENTITYNAME$Entity $ENTITYNAME$Entity
   */
  public void set$ENTITYNAME$Entity($ENTITYNAME$Entity $LOWER_ENTITYNAME$Entity) {
    this.$LOWER_ENTITYNAME$Entity = $LOWER_ENTITYNAME$Entity;$HASMULTILANGPROPERTY BEGIN$
    if($LOWER_ENTITYNAME$Entity != null && (get$ENTITYNAME$ResEntity() == null || get$ENTITYNAME$ResEntity().length == 0)){
      loadResByID($LOWER_ENTITYNAME$Entity.getId());
    }$HASMULTILANGPROPERTY END$
  }$HASMULTILANGPROPERTY BEGIN$

  /**
   *  取VO对应的$ENTITYNAME$多语实体
   *  
   * @return
   */
  public $ENTITYNAME$ResEntity[] get$ENTITYNAME$ResEntity() {
    return $LOWER_ENTITYNAME$ResEntity;
  }

  public void set$ENTITYNAME$ResEntity($ENTITYNAME$ResEntity[] $LOWER_ENTITYNAME$ResEntity) {
    this.$LOWER_ENTITYNAME$ResEntity = $LOWER_ENTITYNAME$ResEntity;
  }$HASMULTILANGPROPERTY END$

  public $ENTITYNAME$VO(Long id) {
    set$ENTITYNAME$Entity(CommonUtils.getEntityByPK($ENTITYNAME$Entity.class, id));$HASMULTILANGPROPERTY BEGIN$
    loadResByID(id);$HASMULTILANGPROPERTY END$
  }
  
  public $ENTITYNAME$VO(Long id, String lang){
    set$ENTITYNAME$Entity(CommonUtils.getEntityByPK($ENTITYNAME$Entity.class, id));$HASMULTILANGPROPERTY BEGIN$
    loadResByID(id, lang);$HASMULTILANGPROPERTY END$
  }$HASMULTILANGPROPERTY BEGIN$
    private void loadResByID(Long id) {
    if (id != null && id > 0L) {
      List<$ENTITYNAME$ResEntity> resEntities =
          CommonUtils.getResEntityByPK($ENTITYNAME$ResEntity.class, id);
      if (resEntities != null) {
        set$ENTITYNAME$ResEntity(resEntities.toArray(new $ENTITYNAME$ResEntity[0]));
      }
    }
  }

  /**
   * 用$ENTITYNAME$Entity及指定语言填充$ENTITYNAME$VO
   * 
   * @param $LOWER_ENTITYNAME$Entity $ENTITYNAME$Entity
   * @param lang 语言
   */
  public void set$ENTITYNAME$Entity($ENTITYNAME$Entity  $LOWER_ENTITYNAME$Entity, String lang) {
    this. $LOWER_ENTITYNAME$Entity =  $LOWER_ENTITYNAME$Entity;
    if( $LOWER_ENTITYNAME$Entity != null){
      loadResByID( $LOWER_ENTITYNAME$Entity.getId(), lang);
    }
  }

  private void loadResByID(Long id, String lang) {
    $ENTITYNAME$ResEntity resEntity = CommonUtils.getResEntityByPK($ENTITYNAME$ResEntity.class, id, lang);
    if (resEntity != null) {
      set$ENTITYNAME$ResEntity(new $ENTITYNAME$ResEntity[] {resEntity});
    }
  }$HASMULTILANGPROPERTY END$

  @Override
  public $ENTITYNAME$Entity pickEntity() {
    return get$ENTITYNAME$Entity();
  }

  @Override
  public Object pickRefEntity() {
    return $IF HASMULTILANGPROPERTY$get$ENTITYNAME$ResEntity(); $ELSE$ null; $END IF$
  }
  
  @Override
  public void putEntity($ENTITYNAME$Entity entity, String lang) {
    $IF HASMULTILANGPROPERTY$ set$ENTITYNAME$Entity(($ENTITYNAME$Entity) entity, lang); $ELSE$ putEntity(entity);$END IF$
  }
  
  /**
   * 根据主键查询$ENTITYNAME$VO
   * 
   * @param id 主键
   * @return
   */
  public static $ENTITYNAME$VO findByID(Long id){
    return findByID($ENTITYNAME$VO.class, id);
  }

  /**
   * 根据主键及语言查询$ENTITYNAME$VO
   * 
   * @param id 主键
   * @param lang 语言
   * @return
   */
  public static $ENTITYNAME$VO findByID(Long id, String lang){
    return findByID($ENTITYNAME$VO.class, id, lang);
  }

  /**
   * 根据业务主键查找所有VO
   *
   * @param bizKey 业务主键
   * @return
   */
  public static List<$ENTITYNAME$VO> findByBizKey($IF BIZKEYCONTAINVARCHAR$String bizKey) {
      return findByBizKey($ENTITYNAME$VO.class, String.valueOf(bizKey)); $ELSE$ Long bizKey) {
      return findByBizKey($ENTITYNAME$VO.class, bizKey); $END IF$
  }

  /**
   * 查询所有$ENTITYNAME$VO
   * 
   * @return 
   */
  public static $ENTITYNAME$VO[] findAll(){
    return ($ENTITYNAME$VO[]) findAll($ENTITYNAME$VO.class, $ENTITYNAME$Entity.class);
  }

  /**
   * 按语言查询所有$ENTITYNAME$VO
   * 
   * @param lang 语言
   * @return
   */
  public static $ENTITYNAME$VO[] findAll(String lang){
    return ($ENTITYNAME$VO[]) findAll($ENTITYNAME$VO.class, $ENTITYNAME$Entity.class, lang);
  }

  @Override
  public Class<$ENTITYNAME$Entity> pickEntityClass() {
    return $ENTITYNAME$Entity.class;
  }

  @Override
  public Class pickResEntityClass() {
      return $IF HASMULTILANGPROPERTY$ $ENTITYNAME$ResEntity.class; $ELSE$ null; $END IF$
  }

  @Override
  public void appendResEntity(Object resEntity) {$IF HASMULTILANGPROPERTY$
    if (resEntity != null){
        List<$ENTITYNAME$ResEntity> resEntityList = new ArrayList<>();
        if(get$ENTITYNAME$ResEntity() != null){
          resEntityList = Arrays.stream(get$ENTITYNAME$ResEntity()).collect(Collectors.toList());
        }

        resEntityList.add(($ENTITYNAME$ResEntity) resEntity);
    } $END IF$
  }
}