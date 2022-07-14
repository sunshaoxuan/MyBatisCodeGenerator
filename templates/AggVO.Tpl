package $VONAMESPACE$;

import jp.co.gutingjun.common.pms.entity.BaseEntity;
import $ENTITYNAMESPACE$.*;
import $MAPPERNAMESPACE$.*;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.List;

/**
 * $ENTITYDESC$AggVO
 *
 * @author $AUTHOR$
 * @create $DATE$
 */
public class $ENTITYNAME$AggVO extends AggregateVO<$ENTITYNAME$Entity> {
  @Autowired $ENTITYNAME$EntityMapper $LOWER_ENTITYNAME$EntityMapper;
$FOREACH AGG VO BEGIN$
  @Autowired $PROPERTYVODATATYPE$Mapper $LOWER_PROPERTYVODATATYPE$Mapper;
$FOREACH AGG VO END$
  /**
   * 通过主实体ID加载整个AggVO
   *
   * @param parentID 主实体ID
   */
  public void loadByParentID(Long parentID) {
    // 初始化主实体
    this.setParentEntity($LOWER_ENTITYNAME$EntityMapper.selectByPrimaryKey(parentID));

    // 初始化子实体
    loadChildrenByParentID(parentID);
  }

$HASBIZKEY BEGIN$
  /**
   * 通过主实体业务关键字加载整个AggVO
   *
   * @param bizKey 业务关键字
   */
  public void loadByBizKey($BIZKEYFIELDJAVATYPE$ bizKey) {
    List<$ENTITYNAME$Entity> parentEntities = $LOWER_ENTITYNAME$EntityMapper.selectByBizKey(bizKey);
    if (parentEntities != null && parentEntities.size() > 0) {
      this.setParentEntity(parentEntities.get(0));

      // 初始化子实体
      loadChildrenByParentID(this.getParentEntity().getId());
    }
  }
$HASBIZKEY END$
  /**
   * 通过主实体ID加载子实体集合
   *
   * @param parentID
   */
  private void loadChildrenByParentID(Long parentID) {
	
$FOREACH AGG VO BEGIN$	
    List<$PROPERTYVODATATYPE$> $LOWER_PROPERTYVODATATYPE$Entities = null;
	$LOWER_PROPERTYVODATATYPE$Entities =
        $LOWER_PROPERTYVODATATYPE$Mapper.selectByBizKey(parentID);
    getChildrenEntities()
        .put($PROPERTYVODATATYPE$.class.getName(), $LOWER_PROPERTYVODATATYPE$Entities.toArray(new BaseEntity[0]));
$FOREACH AGG VO END$
  }
}
