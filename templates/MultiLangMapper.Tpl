package $CLASSROOT$.dao;

$SKIP BEGIN$import $CLASSROOT$.dao.provider.$ENTITYNAME$ResEntitySqlProvider;
$SKIP END$import $CLASSROOT$.entity.$ENTITYNAME$ResEntity;
import org.apache.ibatis.annotations.*;
import org.apache.ibatis.type.JdbcType;

import java.util.List;

/**
 * $ENTITYDESC$多语 Mapper
 *
 * @author $AUTHOR$
  */
@Mapper
public interface $ENTITYNAME$ResEntityMapper {
  @Update({
    "update $TABLENAME$_res set dr=1",
    "where $PKFIELDNAME$ = #{$PKFIELDNAME$,jdbcType=BIGINT} and lang =  #{lang,jdbcType=VARCHAR}"
  })
  int deleteByPrimaryKey(@Param("$PKFIELDNAME$") Long $PKFIELDNAME$, @Param("lang") String lang);

  @Insert({
    "insert into $TABLENAME$_res (",
    // 主键 
    "$PKFIELDNAME$,",
    // 语言 
    "lang, ",$FOREACH MULTILANG PROPERTY BEGIN$
    // $PROPERTYDESC$ 
    "$FIELDNAME$ ,",
$FOREACH MULTILANG PROPERTY END$
    // 更新时间 
	"updated_time) values (",
	// 主键 
	"#{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$} ,",
	// 语言 
	"#{lang,jdbcType=VARCHAR} ,",$FOREACH MULTILANG PROPERTY BEGIN$
    // $PROPERTYDESC$ 
    "#{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$} ,",
$FOREACH MULTILANG PROPERTY END$
	// 更新时间 
    "#{updatedTime,jdbcType=DATE}",
    ")"
  })
  int insert($ENTITYNAME$ResEntity record);

  @Select({
    "select",
    // 主键 
    "$PKFIELDNAME$ ,",
    // 语言 
    "lang ,",$FOREACH MULTILANG PROPERTY BEGIN$
    // $PROPERTYDESC$ 
    "$FIELDNAME$ ,",
$FOREACH MULTILANG PROPERTY END$
    // 更新时间 
    "updated_time",
    "from $TABLENAME$_res",
    "where dr=0 and $PKFIELDNAME$ = #{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$} and lang = #{lang,jdbcType=VARCHAR}"
  })
  @Results({
    // 主键 
    @Result(column = "$PKFIELDNAME$", property = "id", jdbcType = JdbcType.BIGINT, id = true),
    // 语言 
    @Result(column = "lang", property = "lang", jdbcType = JdbcType.VARCHAR, id = true),$FOREACH MULTILANG PROPERTY BEGIN$
    // $PROPERTYDESC$ 
    @Result(column = "$FIELDNAME$", property = "$PROPERTYNAME$", jdbcType = JdbcType.$PROPERTYDATATYPE$),
$FOREACH MULTILANG PROPERTY END$
    // 更新时间 
    @Result(column = "updated_time", property = "updatedTime", jdbcType = JdbcType.DATE),
  })
  $ENTITYNAME$ResEntity selectByPrimaryKey(@Param("$PKFIELDNAME$") Long $PKFIELDNAME$, @Param("lang") String lang);

    @Select({
    "select",
    // 主键 
    "$PKFIELDNAME$ ,",
    // 语言 
    "lang ,",$FOREACH MULTILANG PROPERTY BEGIN$
    // $PROPERTYDESC$ 
    "$FIELDNAME$ ,",
$FOREACH MULTILANG PROPERTY END$
    // 更新时间 
    "updated_time",
    "from $TABLENAME$_res",
    "where dr=0 and $PKFIELDNAME$ = #{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$} "
  })
  @Results({
    // 主键 
    @Result(column = "$PKFIELDNAME$", property = "id", jdbcType = JdbcType.BIGINT, id = true),
    // 语言 
    @Result(column = "lang", property = "lang", jdbcType = JdbcType.VARCHAR, id = true),$FOREACH MULTILANG PROPERTY BEGIN$
    // $PROPERTYDESC$ 
    @Result(column = "$FIELDNAME$", property = "$PROPERTYNAME$", jdbcType = JdbcType.$PROPERTYDATATYPE$),
$FOREACH MULTILANG PROPERTY END$
    // 更新时间 
    @Result(column = "updated_time", property = "updatedTime", jdbcType = JdbcType.DATE),
  })
  List<$ENTITYNAME$ResEntity> selectByEntityID(Long $PKFIELDNAME$);

  @Update({
    "update $TABLENAME$_res",
    "set",$FOREACH MULTILANG PROPERTY BEGIN$
    // $PROPERTYDESC$ 
    "$FIELDNAME$ = #{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$} ,",
$FOREACH MULTILANG PROPERTY END$
    // 更新时间 
    "updated_time = #{updatedTime,jdbcType=DATE} ",
    "where $PKFIELDNAME$ = #{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$} and lang = #{lang,jdbcType=VARCHAR}"
  })
  int updateByPrimaryKey($ENTITYNAME$ResEntity record);
}
