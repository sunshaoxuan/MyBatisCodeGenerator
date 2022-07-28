package $CLASSROOT$.rest.dto;

import java.io.Serializable;
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
 public class $ENTITYNAME$AggDTO implements Serializable{
  /** $ENTITYDESC$ */
  private $ENTITYNAME$DTO parent;
  $FOREACH AGG VO BEGIN$	
  /** $PROPERTYDESC$ */
  private $PROPERTYVODATATYPE_REMOVEVO$DTO[] $LOWER_PROPERTYVODATATYPE_REMOVEVO$DTO; $FOREACH AGG VO END$
}

