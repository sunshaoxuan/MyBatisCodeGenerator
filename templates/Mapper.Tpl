package $MAPPERNAMESPACE$;

import $ENTITYNAMESPACE$.$ENTITYNAME$Entity;
import org.apache.ibatis.annotations.*;
import org.apache.ibatis.type.JdbcType;

/**
 * $ENTITYDESC$ Mapper
 *
 * @author: $AUTHOR$
 * @since: $DATE$
 */
@Mapper
public interface $ENTITYNAME$EntityMapper {
    @Delete({
        "delete from $TABLENAME$",
        "where $PKFIELDNAME$ = #{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$}"
    })
    int deleteByPrimaryKey($PKFIELDJAVATYPE$ $PKFIELDNAME$); 

    @Insert({
        "insert into $TABLENAME$ (",$FOREACH FIELD BEGIN$
        "$FIELDNAME$ $COMMAEXCEPTLAST$",
$FOREACH FIELD END$
		") values (",$FOREACH FIELD BEGIN$
		"#{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$} $COMMAEXCEPTLAST$",
$FOREACH FIELD END$
		")"
    })
    int insert($ENTITYNAME$Entity record);

    @InsertProvider(type=$ENTITYNAME$EntitySqlProvider.class, method="insertSelective")
    int insertSelective($ENTITYNAME$Entity record);

    @Select({
        "select",$FOREACH FIELD BEGIN$
        "$FIELDNAME$ $COMMAEXCEPTLAST$",
$FOREACH FIELD END$
        "from $TABLENAME$",
        "where $PKFIELDNAME$ = #{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$}"
    })
    @Results({
$FOREACH FIELD BEGIN$
        @Result(column="$FIELDNAME$", property="$PROPERTYNAME$", jdbcType=$PROPERTYDATATYPE$ $IDRESULTTAG$) $COMMAEXCEPTLAST$
$FOREACH FIELD END$
    })
    $ENTITYNAME$Entity selectByPrimaryKey($PKFIELDJAVATYPE$ $PKFIELDNAME$);

    @UpdateProvider(type=$ENTITYNAME$EntitySqlProvider.class, method="updateByPrimaryKeySelective")
    int updateByPrimaryKeySelective($ENTITYNAME$Entity record);

    @Update({
        "update $TABLENAME$",
        "set",$FOREACH FIELD EXCEPT PK BEGIN$
		"$FIELDNAME$ = #{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$} $COMMAEXCEPTLAST$",
$FOREACH FIELD EXCEPT PK END$
        "where $PKFIELDNAME$ = #{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$}"
    })
    int updateByPrimaryKey($ENTITYNAME$Entity record);
}