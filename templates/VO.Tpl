package $VONAMESPACE$;

import jp.co.kanran.common.constant.Language;
import jp.co.gutingjun.common.pms.entity.*;
import $ENTITYNAMESPACE$.*;
import jp.co.gutingjun.pms.utils.VOUtils;

import java.util.*;


/**
 * $ENTITYDESC$VO
 *
 * @author $AUTHOR$
 * @since $DATE$
 */
public class $ENTITYNAME$VO {
  /** $ENTITYDESC$VO无参构造器 */
  public $ENTITYNAME$VO() {}

  /** 按给定ID初始化$ENTITYDESC$VO构造器 */
  public $ENTITYNAME$VO(Long id) {
    //VO初始化
    VOUtils.loadVOByID($ENTITYNAME$Entity.class.getSimpleName(), id, this);
    initSubEntities(id);
  }

  public void initSubEntities(Long id) {$FOREACH AGG VO BEGIN$
    //AggSubVO初始化: $PROPERTYDESC$
    this.$PROPERTYSETMETHOD$(($
    $)VOUtils.loadVOByBizKey($UPPER_PROPERTYNAME$Entity.class.getName(), id));
    if (this.$PROPERTYNAME$ != null && this.$PROPERTYNAME$.length > 0) {
      for (int i=0; i< this.$PROPERTYNAME$.length; i++) {
        this.$PROPERTYNAME$[i].initSubEntities($PKGETMETHOD$());
      }
    }
$FOREACH AGG VO END$
  }

$HASMULTILANGPROPERTY BEGIN$
  /** 按给定ID及语言初始化多语$ENTITYDESC$VO构造器 */
  public $ENTITYNAME$VO(Long id, Language lang) {
    VOUtils.loadVOByID($ENTITYNAME$Entity.class.getSimpleName(), id, this);
    MultiLangEntity mlEntity =
        VOUtils.loadResEntityByMapper(
            $ENTITYNAME$ResEntity.class.getSimpleName(), id, lang.toString());
$FOREACH MULTILANG VO BEGIN$
    this.$PROPERTYSETMETHOD$(new MultiLangVO[] {VOUtils.getMultiLangVO(mlEntity,"$PROPERTYNAME$")});
$FOREACH MULTILANG VO END$
  }
$HASMULTILANGPROPERTY END$
$FOREACH VO BEGIN$

  /** $PROPERTYDESC$ */
  private $PROPERTYVODATATYPE$ $PROPERTYNAME$;

  public $PROPERTYVODATATYPE$ $PROPERTYGETMETHOD$() {
    return $PROPERTYNAME$;
  }

  public void $PROPERTYSETMETHOD$($PROPERTYVODATATYPE$ value) {
    this.$PROPERTYNAME$ = value;
  }$FOREACH VO END$

$FOREACH MULTILANG VO BEGIN$
  /** $PROPERTYDESC$ */
  private MultiLangVO[] $PROPERTYNAME$;

  public void $PROPERTYSETMETHOD$(MultiLangVO[] value) {
    this.$PROPERTYNAME$ = value;
  }

  public MultiLangVO[] $PROPERTYGETMETHOD$() {
    if ($PROPERTYNAME$ == null) {
      $PROPERTYNAME$ = VOUtils.getMultiLangRes($ENTITYNAME$ResEntity.class.getSimpleName(), $PKGETMETHOD$(), "$PROPERTYNAME$");
    }

    return $PROPERTYNAME$;
  }
  
  public MultiLangVO $PROPERTYGETMETHOD$(String lang) {
    if ($PROPERTYGETMETHOD$() != null) {
      for (int i = 0; i < $PROPERTYGETMETHOD$().length; i++) {
        if ($PROPERTYGETMETHOD$()[i].getLang().equals(lang)) {
          return $PROPERTYGETMETHOD$()[i];
        }
      }
    }

    return null;
  } $FOREACH MULTILANG VO END$
}
