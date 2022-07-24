package $CLASSROOT$.rest.request;

import $CLASSROOT$.entity.*;
import $CLASSROOT$.vo.*;
import lombok.Data;

/**
 * $ENTITYDESC$AggVO请求数据
 *
 * @author $AUTHOR$
 * @create $DATE$
 */
 @Data
 public class $ENTITYNAME$AggVORequest {
  /** $ENTITYDESC$ */
  private $ENTITYNAME$Entity parent;
  $FOREACH AGG VO BEGIN$	
  /** $PROPERTYDESC$ */
  private $PROPERTYVODATATYPE$[] $LOWER_PROPERTYVODATATYPE$; $FOREACH AGG VO END$
}

