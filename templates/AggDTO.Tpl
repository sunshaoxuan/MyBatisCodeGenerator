package $CLASSROOT$.rest.dto;

import io.swagger.annotations.ApiModelProperty;
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
  @ApiModelProperty(value = "$ENTITYDESC$主实体", name = "$ENTITYNAME$DTO", example = "")
  private $ENTITYNAME$DTO parent;
  $FOREACH AGG VO BEGIN$	
  /** $PROPERTYDESC$ */
  @ApiModelProperty(value = "$PROPERTYDESC$子实体集合", name = "$LOWER_PROPERTYVODATATYPE_REMOVEVO$DTO", example = "")
  private $PROPERTYVODATATYPE_REMOVEVO$DTO[] $LOWER_PROPERTYVODATATYPE_REMOVEVO$DTO; $FOREACH AGG VO END$
}

