package $ENTITYNAMESPACE$;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.Date;

/**
 * $ENTITYDESC$
 *
 * @author $AUTHOR$
 * @since $DATE$
 */
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class $ENTITYNAME$Entity $PARENTCLASS$ $INTERFACES$ {$FOREACH PROPERTY BEGIN$
  /** $PROPERTYDESC$ */
  private $PROPERTYJAVATYPE$ $PROPERTYNAME$;
$FOREACH PROPERTY END$
}
