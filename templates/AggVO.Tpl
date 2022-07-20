package $VONAMESPACE$;

import $ENTITYNAMESPACE$.*;
import lombok.Data;

import java.util.List;

/**
 * $ENTITYDESC$AggVO
 *
 * @author $AUTHOR$
 * @create $DATE$
 */
 @Data
 public class $ENTITYNAME$AggVO {
  /** $ENTITYDESC$ */
  private $ENTITYNAME$Entity parent;
  $FOREACH AGG VO BEGIN$	
  /** $PROPERTYDESC$ */
  private $PROPERTYVODATATYPE$[] $LOWER_PROPERTYVODATATYPE$; $FOREACH AGG VO END$
}

