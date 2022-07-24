package $CLASSROOT$.entity;

import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;
import jp.co.gutingjun.common.multilang.MultiLangResource;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Date;

/**
 * $ENTITYDESC$多语
 *
 * @author $AUTHOR$
 * @since $DATE$
 */
  @ApiModel(value = "$ENTITYNAME$ResEntity", description = "$ENTITYDESC$多语")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class $ENTITYNAME$ResEntity {
  /** 主键 */
  @ApiModelProperty(value = "id", name = "主键", example = "")
  @MultiLangResource(catelog = "common", resourceid = "bd0001")
  private Long id;
  /** 语言 */
  @ApiModelProperty(value = "lang", name = "语言", example = "")
  @MultiLangResource(catelog = "common", resourceid = "bd0023")
  private String lang;
  /** 更新时间 */
  @ApiModelProperty(value = "updatedTime", name = "更新时间", example = "")
  @MultiLangResource(catelog = "common", resourceid = "bd0007")
  private Date updatedTime;
  $FOREACH MULTILANG PROPERTY BEGIN$
  /** $PROPERTYDESC$ */
  @ApiModelProperty(value = "$PROPERTYDESC$", name = "$PROPERTYNAME$", example = "")
  @MultiLangResource(catelog = "$MULTILANGRESCATALOG$", resourceid = "$MULTILANGRESID$")
  private $PROPERTYJAVATYPE$ $PROPERTYNAME$; $FOREACH MULTILANG PROPERTY END$
}