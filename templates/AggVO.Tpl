package $CLASSROOT$.vo.aggvo;

import $CLASSROOT$.vo.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * $ENTITYDESC$AggVO
 *
 * @author $AUTHOR$
 * @create $DATE$
 */
 public class $ENTITYNAME$AggVO extends AggVO {
  // $ENTITYDESC$ 
  private $ENTITYNAME$VO parent;
  $FOREACH AGG VO BEGIN$	
  // $PROPERTYDESC$ 
  private $PROPERTYVODATATYPE$[] $LOWER_PROPERTYVODATATYPE$;
    $FOREACH AGG VO END$
  @Override
  public ValueObject getParent() {
    return parent;
  }

  @Override
  public void setParent(ValueObject parent) {
    this.parent = ($ENTITYNAME$VO) parent;
  }

  $FOREACH AGG VO BEGIN$	
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

  // 取主实体ID 
  @Override
  public Long pickParentID() {
    if (getParent() != null) {
      return getParent().pickId();
    }

    return -1L;
  }

  // 取主实体类型 
  @Override
  public Class pickParentClass() {
    return $ENTITYNAME$VO.class;
  }

  // 取子实体类型列表 
  @Override
  public List<Class> pickSubClasses() {
    List<Class> entityClasses = new ArrayList<Class>();  $FOREACH AGG VO BEGIN$	
    entityClasses.add($PROPERTYVODATATYPE$.class);  $FOREACH AGG VO END$
    return entityClasses;
  }

  // 取子实体对象列表 
  @Override
  public List pickSubVOList(Class subVOClazz) {$FOREACH AGG VO BEGIN$
    if (subVOClazz.equals($PROPERTYVODATATYPE$.class)) {
      $PROPERTYVODATATYPE$[] subVOs = get$PROPERTYVODATATYPE$();
      if (subVOs == null) {
        return null;
      } else {
        return new ArrayList<>(Arrays.asList(subVOs));
      }
    } $FOREACH AGG VO END$
    return null;
  }

  // 设置子实体对象集合
  @Override
  public void putSubVOList(Class subVOClazz, List subVOs) {$FOREACH AGG VO BEGIN$
    if (subVOClazz.equals($PROPERTYVODATATYPE$.class)) {
      set$PROPERTYVODATATYPE$(($PROPERTYVODATATYPE$[]) subVOs.toArray(new $PROPERTYVODATATYPE$[0]));
    } $FOREACH AGG VO END$
  }
}

