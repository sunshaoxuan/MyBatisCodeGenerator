package $MAPPERNAMESPACE$;

import $SQLPROVIDERNAMESPACE$.$ENTITYNAME$ResEntitySqlProvider;
import $ENTITYNAMESPACE$.$ENTITYNAME$ResEntity;
import org.apache.ibatis.annotations.*;
import org.apache.ibatis.type.JdbcType;

import java.util.List;

/**
 * $ENTITYDESC$多语 Mapper
 *
 * @author $AUTHOR$
 * @since $DATE$
 */
@Mapper
public interface $ENTITYNAME$ResEntityMapper {
  @Delete({
    "delete from $TABLENAME$_res",
    "where $PKFIELDNAME$ = #{$PKFIELDNAME$,jdbcType=JdbcType.BIGINT} and lang =  #{lang,jdbcType=JdbcType.VARCHAR}"
  })
  int deleteByPrimaryKey(Long $PKFIELDNAME$, String lang);

  @Insert({
    "insert into $TABLENAME$_res (",
    /** 主键 */
    "$PKFIELDNAME$,",
    /** 语言 */
    "lang, ",$FOREACH MULTILANG PROPERTY BEGIN$
    /** $PROPERTYDESC$ */
    "$FIELDNAME$ ,",
$FOREACH MULTILANG PROPERTY END$
    /** 更新时间 */
	"updated_time) values (",
	/** 主键 */
	"#{$PKFIELDNAME$,jdbcType=$PKFIELDDATATYPE$} ,",
	/** 语言 */
	"#{lang,jdbcType=JdbcType.VARCHAR} ,",$FOREACH MULTILANG PROPERTY BEGIN$
    /** $PROPERTYDESC$ */
    "#{$FIELDNAME$,jdbcType=$PROPERTYDATATYPE$} ,",
$FOREACH MULTILANG PROPERTY END$
	/** 更新时间 */
    "#{updatedTime,jdbcType=JdbcType.TIMESTAMP}",
    ")"
  })
  int insert($ENTITYNAME$ResEntity record);

  @InsertProvider(type = $ENTITYNAME$ResEntitySqlProvider.class, method = "insertSelective")
  int insertSelective($ENTITYNAME$ResEntity record);

  @Select({
    "select",
    /** 主键 */
    "$PKFIELDNAME$ ,",
    /** 语言 */
    "lang ,",$FOREACH MULTILANG PROPERTY BEGIN$
    /** $PROPERTYDESC$ */
    "$FIELDNAME$ ,",
$FOREACH MULTILANG PROPERTY END$
    /** 更新时间 */
    "updated_time",
    "from $TABLENAME$_res",
    "where $PKFIELDNAME$ = #{$PKFIELDNAME$,jdbcType=$PKFIELDDATATYPE$} and lang = #{lang,jdbcType=JdbcType.VARCHAR}"
  })
  @Results({
    /** 主键 */
    @Result(column = "$PKFIELDNAME$", property = "id", jdbcType = JdbcType.BIGINT, id = true),
    /** 语言 */
    @Result(column = "lang", property = "lang", jdbcType = JdbcType.VARCHAR, id = true),$FOREACH MULTILANG PROPERTY BEGIN$
    /** $PROPERTYDESC$ */
    @Result(column = "$FIELDNAME$", property = "$PROPERTYNAME$", jdbcType = $PROPERTYDATATYPE$),
$FOREACH MULTILANG PROPERTY END$
    /** 更新时间 */
    @Result(column = "updated_time", property = "updatedTime", jdbcType = JdbcType.TIMESTAMP),
  })
  $ENTITYNAME$ResEntity selectByPrimaryKey(Long $PKFIELDNAME$, String lang);

    @Select({
    "select",
    /** 主键 */
    "$PKFIELDNAME$ ,",
    /** 语言 */
    "lang ,",$FOREACH MULTILANG PROPERTY BEGIN$
    /** $PROPERTYDESC$ */
    "$FIELDNAME$ ,",
$FOREACH MULTILANG PROPERTY END$
    /** 更新时间 */
    "updated_time",
    "from $TABLENAME$_res",
    "where $PKFIELDNAME$ = #{$PKFIELDNAME$,jdbcType=$PKFIELDDATATYPE$} and lang = #{lang,jdbcType=JdbcType.VARCHAR}"
  })
  @Results({
    /** 主键 */
    @Result(column = "$PKFIELDNAME$", property = "id", jdbcType = JdbcType.BIGINT, id = true),
    /** 语言 */
    @Result(column = "lang", property = "lang", jdbcType = JdbcType.VARCHAR, id = true),$FOREACH MULTILANG PROPERTY BEGIN$
    /** $PROPERTYDESC$ */
    @Result(column = "$FIELDNAME$", property = "$PROPERTYNAME$", jdbcType = $PROPERTYDATATYPE$),
$FOREACH MULTILANG PROPERTY END$
    /** 更新时间 */
    @Result(column = "updated_time", property = "updatedTime", jdbcType = JdbcType.TIMESTAMP),
  })
  List<$ENTITYNAME$ResEntity> selectByEntityID(Long $PKFIELDNAME$);

  @UpdateProvider(type = $ENTITYNAME$ResEntitySqlProvider.class, method = "updateByPrimaryKeySelective")
  int updateByPrimaryKeySelective($ENTITYNAME$ResEntity record);

  @Update({
    "update $TABLENAME$_res",
    "set",$FOREACH MULTILANG PROPERTY BEGIN$
    /** $PROPERTYDESC$ */
    "$FIELDNAME$ = #{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$} ,",
$FOREACH MULTILANG PROPERTY END$
    /** 更新时间 */
    "updated_time = #{updatedTime,jdbcType=JdbcType.TIMESTAMP} ",
    "where $PKFIELDNAME$ = #{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$} and lang = #{lang,jdbcType=JdbcType.VARCHAR}"
  })
  int updateByPrimaryKey($ENTITYNAME$ResEntity record);
}
