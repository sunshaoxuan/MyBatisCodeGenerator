package $ENTITYNAMESPACE$;

import jp.co.gutingjun.common.multilang.MultiLangResource;
import $MULTILANGBASECLASS$;
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
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class $ENTITYNAME$ResEntity extends MultiLangEntity {$FOREACH MULTILANG PROPERTY BEGIN$
  /** $PROPERTYDESC$ */
  @MultiLangResource(catelog = "$MULTILANGRESCATALOG$", resourceid = "$MULTILANGRESID$")
  private $PROPERTYJAVATYPE$ $PROPERTYNAME$;
$FOREACH MULTILANG PROPERTY END$
}