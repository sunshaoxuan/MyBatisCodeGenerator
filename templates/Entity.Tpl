package $CLASSROOT$.entity;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.databind.annotation.JsonDeserialize;
import com.fasterxml.jackson.databind.annotation.JsonSerialize;
import com.fasterxml.jackson.databind.ser.std.ToStringSerializer;
import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;
import jp.co.gutingjun.common.multilang.MultiLangResource;
import jp.co.gutingjun.common.util.DateTimeDeserializers;
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
  */
 @ApiModel(value = "$ENTITYNAME$Entity", description = "$ENTITYDESC$")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
@MultiLangResource(catelog = "$MULTILANGRESCATALOG$", resourceid = "mt0000")
public class $ENTITYNAME$Entity $PARENTCLASS$ $INTERFACES$ {$FOREACH PROPERTY BEGIN$
  // $PROPERTYDESC$ 
  @ApiModelProperty(value = "$PROPERTYDESC$", name = "$PROPERTYNAME$", example = "")
  @MultiLangResource(catelog = "$MULTILANGRESCATALOG$", resourceid = "$MULTILANGRESID$")  $IFFORMATTEDDATE BEGIN$
  @JsonDeserialize(using = DateTimeDeserializers.class)
  @DateTimeFormat(pattern = "yyyy-MM-dd HH:mm:ss")
  @JsonFormat(pattern = "yyyy-MM-dd HH:mm:ss", timezone = "GMT+9") $IFFORMATTEDDATE END$  $BIGINT BEGIN$
  @JsonSerialize(using = ToStringSerializer.class) $BIGINT END$
  private $PROPERTYJAVATYPE$ $PROPERTYNAME$;
$FOREACH PROPERTY END$
}
