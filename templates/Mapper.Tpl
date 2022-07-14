package $MAPPERNAMESPACE$;

import $SQLPROVIDERNAMESPACE$.$ENTITYNAME$EntitySqlProvider;
import $ENTITYNAMESPACE$.$ENTITYNAME$Entity;
import org.apache.ibatis.annotations.*;
import org.apache.ibatis.type.JdbcType;

$HASBIZKEY BEGIN$import java.util.List;$HASBIZKEY END$

/**
 * $ENTITYDESC$ Mapper
 *
 * @author $AUTHOR$
 * @since $DATE$
 */
@Mapper
public interface $ENTITYNAME$EntityMapper {
    @Delete({
        "delete from $TABLENAME$",
        "where $PKFIELDNAME$ = #{$PKFIELDNAME$,jdbcType=$PKFIELDDATATYPE$}"
    })
    int deleteByPrimaryKey($PKFIELDJAVATYPE$ $PKFIELDNAME$); 

    @Insert({
        "insert into $TABLENAME$ (",$FOREACH FIELD BEGIN$
        /** $PROPERTYDESC$ */
        "$FIELDNAME$ $COMMAEXCEPTLAST$", $FOREACH FIELD END$
		") values (",$FOREACH FIELD BEGIN$
        /** $PROPERTYDESC$ */
		"#{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$} $COMMAEXCEPTLAST$", $FOREACH FIELD END$
		")"
    })
    int insert($ENTITYNAME$Entity record);

    @InsertProvider(type=$ENTITYNAME$EntitySqlProvider.class, method="insertSelective")
    int insertSelective($ENTITYNAME$Entity record);

    @Select({
        "select",$FOREACH FIELD BEGIN$
        /** $PROPERTYDESC$ */
        "$FIELDNAME$ $COMMAEXCEPTLAST$", $FOREACH FIELD END$
        "from $TABLENAME$",
        "where $PKFIELDNAME$ = #{$PKFIELDNAME$,jdbcType=$PKFIELDDATATYPE$}"
    })
    @Results({$FOREACH FIELD BEGIN$
        /** $PROPERTYDESC$ */
        @Result(column="$FIELDNAME$", property="$PROPERTYNAME$", jdbcType=$PROPERTYDATATYPE$ $IDRESULTTAG$) $COMMAEXCEPTLAST$ $FOREACH FIELD END$
    })
    $ENTITYNAME$Entity selectByPrimaryKey($PKFIELDJAVATYPE$ $PKFIELDNAME$);
$HASBIZKEY BEGIN$
    @Select({
        "select",$FOREACH FIELD BEGIN$
        /** $PROPERTYDESC$ */
        "$FIELDNAME$ $COMMAEXCEPTLAST$",$FOREACH FIELD END$
        "from $TABLENAME$",
        "where $BIZKEYFIELDNAME$ = #{$BIZKEYPROPERTYNAME$,jdbcType=$BIZKEYFIELDDATATYPE$}"
    })
    @Results({$FOREACH FIELD BEGIN$
        /** $PROPERTYDESC$ */
        @Result(column="$FIELDNAME$", property="$PROPERTYNAME$", jdbcType=$PROPERTYDATATYPE$ $IDRESULTTAG$) $COMMAEXCEPTLAST$ $FOREACH FIELD END$
    })
    List<$ENTITYNAME$Entity> selectByBizKey($BIZKEYFIELDJAVATYPE$ $BIZKEYPROPERTYNAME$);
$HASBIZKEY END$
    @UpdateProvider(type=$ENTITYNAME$EntitySqlProvider.class, method="updateByPrimaryKeySelective")
    int updateByPrimaryKeySelective($ENTITYNAME$Entity record);

    @Update({
        "update $TABLENAME$",
        "set",$FOREACH FIELD EXCEPT PK BEGIN$
        /** $PROPERTYDESC$ */
		"$FIELDNAME$ = #{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$} $COMMAEXCEPTLAST$", $FOREACH FIELD EXCEPT PK END$
        "where $PKFIELDNAME$ = #{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$}"
    })
    int updateByPrimaryKey($ENTITYNAME$Entity record);
}