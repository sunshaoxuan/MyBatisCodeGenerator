package $CLASSROOT$.dao;

import $CLASSROOT$.dao.provider.$ENTITYNAME$EntitySqlProvider;
import $CLASSROOT$.entity.$ENTITYNAME$Entity;
import org.apache.ibatis.annotations.*;
import org.apache.ibatis.type.JdbcType;

import java.util.List;

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
        @Result(column="$FIELDNAME$", property="$PROPERTYNAME$", jdbcType=JdbcType.$PROPERTYDATATYPE$ $IDRESULTTAG$) $COMMAEXCEPTLAST$ $FOREACH FIELD END$
    })
    $ENTITYNAME$Entity selectByPrimaryKey($PKFIELDJAVATYPE$ $PKFIELDNAME$);

    @Select({
        "select",$FOREACH FIELD BEGIN$
        /** $PROPERTYDESC$ */
        "$FIELDNAME$ $COMMAEXCEPTLAST$", $FOREACH FIELD END$
        "from $TABLENAME$"
    })
    @Results({$FOREACH FIELD BEGIN$
        /** $PROPERTYDESC$ */
        @Result(column="$FIELDNAME$", property="$PROPERTYNAME$", jdbcType=JdbcType.$PROPERTYDATATYPE$ $IDRESULTTAG$) $COMMAEXCEPTLAST$ $FOREACH FIELD END$
    })
    List<$ENTITYNAME$Entity> selectAll();

$HASBIZKEY BEGIN$
    @Select({
        "select",$FOREACH FIELD BEGIN$
        /** $PROPERTYDESC$ */
        "$FIELDNAME$ $COMMAEXCEPTLAST$",$FOREACH FIELD END$
        "from $TABLENAME$",
        "where (1=2$BIZKEYWHERECONDITION$)"
    })
    @Results({$FOREACH FIELD BEGIN$
        /** $PROPERTYDESC$ */
        @Result(column="$FIELDNAME$", property="$PROPERTYNAME$", jdbcType=JdbcType.$PROPERTYDATATYPE$ $IDRESULTTAG$) $COMMAEXCEPTLAST$ $FOREACH FIELD END$
    })
    List<$ENTITYNAME$Entity> selectByBizKey($BIZKEYFIELDJAVATYPE$ bizKeyValue);
$HASBIZKEY END$
    @UpdateProvider(type=$ENTITYNAME$EntitySqlProvider.class, method="updateByPrimaryKeySelective")
    int updateByPrimaryKeySelective($ENTITYNAME$Entity record);

    @Update({
        "update $TABLENAME$",
        "set",$FOREACH FIELD EXCEPT PK BEGIN$
        /** $PROPERTYDESC$ */ $IFVERSION BEGIN$
        "$FIELDNAME$ = $FIELDNAME$ + 1 ,", $IFVERSION ELSE$ 
		"$FIELDNAME$ = #{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$} $COMMAEXCEPTLAST$", $IFVERSION END$  $FOREACH FIELD EXCEPT PK END$
        "where $PKFIELDNAME$ = #{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$}" $HASVERSION BEGIN$ ,
        " and version = #{version,jdbcType=INTEGER}" $HASVERSION END$ 
    })
    int updateByPrimaryKey($ENTITYNAME$Entity record);
}