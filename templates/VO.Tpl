package $VONAMESPACE$;

import jp.co.gutingjun.common.pms.entity.MultiLangVO;
import jp.co.gutingjun.common.pms.entity.UpmsUser;
import $ENTITYNAMESPACE$.$ENTITYNAME$Entity;$HASMULTILANGPROPERTY BEGIN$
import jp.co.gutingjun.common.pms.entity.MultiLangEntity;
import $ENTITYNAMESPACE$.$ENTITYNAME$ResEntity;
$HASMULTILANGPROPERTY END$
import jp.co.gutingjun.pms.utils.VOUtils;
import jp.co.kanran.common.constant.Language;

import java.util.Collections;
import java.util.Date;
import java.util.List;

/**
 * $ENTITYDESC$VO
 *
 * @author $AUTHOR$
 * @since $DATE$
 */
public class $ENTITYNAME$VO {
  public $ENTITYNAME$VO() {}

  public $ENTITYNAME$VO(Long id) {
    VOUtils.loadBaseDocVOByID($ENTITYNAME$Entity.class.getSimpleName(), id, this);
  }
$HASMULTILANGPROPERTY BEGIN$
  public $ENTITYNAME$VO(Long id, Language lang) {
    VOUtils.loadBaseDocVOByID($ENTITYNAME$Entity.class.getSimpleName(), id, this);
    MultiLangEntity mlEntity =
        VOUtils.loadBaseDocResEntityByMapper(
            $ENTITYNAME$ResEntity.class.getSimpleName(), id, lang.toString());
$FOREACH MULTILANG VO BEGIN$
    this.$PROPERTYSETMETHOD$(Collections.singletonList(VOUtils.getMultiLangVO(mlEntity,"$PROPERTYNAME$")));
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
  }
$FOREACH VO END$

$FOREACH MULTILANG VO BEGIN$
  /** $PROPERTYDESC$ */
  private List<MultiLangVO> $PROPERTYNAME$;

  public void $PROPERTYSETMETHOD$(List<MultiLangVO> value) {
    this.$PROPERTYNAME$ = value;
  }

  public List<MultiLangVO> $PROPERTYGETMETHOD$() {
    if ($PROPERTYNAME$ == null) {
      $PROPERTYNAME$ = VOUtils.getMultiLangRes($ENTITYNAME$ResEntity.class.getSimpleName(), $PKGETMETHOD$(), "$PROPERTYNAME$");
    }

    return $PROPERTYNAME$;
  }
$FOREACH MULTILANG VO END$
}
