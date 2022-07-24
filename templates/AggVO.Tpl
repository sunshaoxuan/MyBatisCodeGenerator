package $CLASSROOT$.vo;

import jp.co.gutingjun.common.pms.entity.AggVO;
import $CLASSROOT$.entity.*;

import java.util.ArrayList;
import java.util.List;

/**
 * $ENTITYDESC$AggVO
 *
 * @author $AUTHOR$
 * @create $DATE$
 */
 public class $ENTITYNAME$AggVO extends AggVO {
  /** $ENTITYDESC$ */
  private $ENTITYNAME$VO parent;

  public $ENTITYNAME$VO getParent() {
    return parent;
  }

  public void setParent($ENTITYNAME$VO parent) {
    this.parent = parent;
  }
  
  public void setParent($ENTITYNAME$Entity parentEntity) {
    if (this.parent == null) {
      this.parent = new $ENTITYNAME$VO();
    }

    this.parent.set$ENTITYNAME$Entity(parentEntity);
  }

  $FOREACH AGG VO BEGIN$	
  /** $PROPERTYDESC$ */
  private $PROPERTYVODATATYPE$[] $LOWER_PROPERTYVODATATYPE$;

  public $PROPERTYVODATATYPE$[] get$PROPERTYVODATATYPE$() {
    return $LOWER_PROPERTYVODATATYPE$;
  }

  public void set$PROPERTYVODATATYPE$($PROPERTYVODATATYPE$[] subVOs) {
    this.$LOWER_PROPERTYVODATATYPE$ = subVOs;
  }

  public void set$PROPERTYVODATATYPE$(ArrayList<$PROPERTYVODATATYPE$> subVOs) {
    set$PROPERTYVODATATYPE$(subVOs.toArray(new $PROPERTYVODATATYPE$[0]));
  } 
  $FOREACH AGG VO END$
  @Override
  public Class ensureParentClass() {
    return $ENTITYNAME$VO.class;
  }

  @Override
  public List<Class> ensureSubClasses() {
    List<Class> entityClasses = new ArrayList<Class>();  $FOREACH AGG VO BEGIN$	
    entityClasses.add($PROPERTYVODATATYPE$.class);  $FOREACH AGG VO END$
    return entityClasses;
  }
}

