package $CLASSROOT$.rest.dto;

import io.swagger.annotations.ApiModelProperty;
import java.io.Serializable;
import $CLASSROOT$.entity.$ENTITYNAME$Entity;$HASMULTILANGPROPERTY BEGIN$
import $CLASSROOT$.entity.$ENTITYNAME$ResEntity;$HASMULTILANGPROPERTY END$

import lombok.Data;

/**
 * $ENTITYDESC$请求数据
 *
 * @author $AUTHOR$
 * @create $DATE$
 */
 @Data
 public class $ENTITYNAME$DTO implements Serializable{
  //"$ENTITYDESC$实体"
  @ApiModelProperty(value = "$ENTITYDESC$实体", name = "$LOWER_ENTITYNAME$Entity", example = "")
  private $ENTITYNAME$Entity $LOWER_ENTITYNAME$Entity;$HASMULTILANGPROPERTY BEGIN$

  //$ENTITYDESC$多语数据实体
  @ApiModelProperty(value = "$ENTITYDESC$多语数据实体", name = "$LOWER_ENTITYNAME$ResEntity", example = "")
  private $ENTITYNAME$ResEntity[] $LOWER_ENTITYNAME$ResEntity;$HASMULTILANGPROPERTY END$
}

