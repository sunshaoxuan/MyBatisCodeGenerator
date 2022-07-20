package $ENTITYNAMESPACE$;

import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;
import jp.co.gutingjun.common.multilang.MultiLangResource;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.format.annotation.DateTimeFormat;

import java.util.Date;

/**
 * $ENTITYDESC$
 *
 * @author $AUTHOR$
 * @since $DATE$
 */
 @ApiModel(value = "$ENTITYNAME$Entity", description = "$ENTITYDESC$")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
@MultiLangResource(catelog = "$MULTILANGRESCATALOG$", resourceid = "mt0000")
public class $ENTITYNAME$Entity $PARENTCLASS$ $INTERFACES$ {$FOREACH PROPERTY BEGIN$
  /** $PROPERTYDESC$ */
  @ApiModelProperty(value = "$PROPERTYDESC$", name = "$PROPERTYNAME$", example = "")
  @MultiLangResource(catelog = "$MULTILANGRESCATALOG$", resourceid = "$MULTILANGRESID$")  $IFFORMATTEDDATE BEGIN$
  @DateTimeFormat(pattern = "yyyy-MM-dd HH:mm:ss") $IFFORMATTEDDATE END$
  private $PROPERTYJAVATYPE$ $PROPERTYNAME$;
$FOREACH PROPERTY END$
}
