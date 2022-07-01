package $ENTITYNAMESPACE$;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

/**
 * $ENTITYDESC$
 *
 * @author: $AUTHOR$
 * @since: $DATE$
 */
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class $ENTITYNAME$Entity $PARENT$ $INTERFACES$ {$FOREACH PROPERTY BEGIN$
  /** $PROPERTYDESC$ */
  private $PROPERTYJAVATYPE$ $PROPERTYNAME$;
$FOREACH PROPERTY END$
}
