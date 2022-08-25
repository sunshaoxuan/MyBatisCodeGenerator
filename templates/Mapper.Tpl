package $CLASSROOT$.dao;

$SKIP BEGIN$import $CLASSROOT$.dao.provider.$ENTITYNAME$EntitySqlProvider;
$SKIP END$import $CLASSROOT$.entity.$ENTITYNAME$Entity;
import org.apache.ibatis.annotations.*;
import org.apache.ibatis.type.JdbcType;

import java.util.ArrayList;
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
    @Update({
        "update $TABLENAME$ set dr=1 ",
        "where $PKFIELDNAME$ = #{$PKFIELDNAME$,jdbcType=$PKFIELDDATATYPE$}"$HASVERSION BEGIN$,
        " and version = #{version,jdbcType=INTEGER}"$HASVERSION END$
    })
    int deleteByPrimaryKey(@Param("$PKFIELDNAME$") $PKFIELDJAVATYPE$ $PKFIELDNAME$$HASVERSION BEGIN$,@Param("version") Integer version$HASVERSION END$); 

  @Update({
    "<script>update $TABLENAME$ set dr=1 ",
    "where id in ",
    "<foreach collection='collection' item='item' index='index' separator=',' open='(' close=')'>",
    " #{item,jdbcType=BIGINT}",
    "</foreach>",
    "</script>"
  })
  int batchDelete(ArrayList<Long> ids);

    @Insert({
        "insert into $TABLENAME$ (",$FOREACH FIELD BEGIN$
        // $PROPERTYDESC$ 
        "$FIELDNAME$ $COMMAEXCEPTLAST$", $FOREACH FIELD END$
		") values (",$FOREACH FIELD BEGIN$
        // $PROPERTYDESC$ 
		"#{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$} $COMMAEXCEPTLAST$", $FOREACH FIELD END$
		")"
    })
    int insert($ENTITYNAME$Entity record);

  @Insert({
    "<script>insert into $TABLENAME$ (",$FOREACH FIELD BEGIN$
    // $PROPERTYDESC$ 
    "$FIELDNAME$ $COMMAEXCEPTLAST$", $FOREACH FIELD END$
	") values",
    "<foreach collection='collection' item='item' index='index' separator=','>",
    "(" ,$FOREACH FIELD BEGIN$
    // $PROPERTYDESC$ 
    "#{item.$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$} $COMMAEXCEPTLAST$",$FOREACH FIELD END$
    ")",
    "</foreach>",
    "</script>"
  })
  void batchInsert(ArrayList<$ENTITYNAME$Entity> records);

    @Select({
        "select",$FOREACH FIELD BEGIN$
        // $PROPERTYDESC$ 
        "$FIELDNAME$ $COMMAEXCEPTLAST$", $FOREACH FIELD END$
        "from $TABLENAME$",
        "where dr=0 and $PKFIELDNAME$ = #{$PKFIELDNAME$,jdbcType=$PKFIELDDATATYPE$}"
    })
    @Results({$FOREACH FIELD BEGIN$
        // $PROPERTYDESC$ 
        @Result(column="$FIELDNAME$", property="$PROPERTYNAME$", jdbcType=JdbcType.$PROPERTYDATATYPE$ $IDRESULTTAG$) $COMMAEXCEPTLAST$ $FOREACH FIELD END$
    })
    $ENTITYNAME$Entity selectByPrimaryKey($PKFIELDJAVATYPE$ $PKFIELDNAME$);

    @Select({
        "select",$FOREACH FIELD BEGIN$
        // $PROPERTYDESC$ 
        "$FIELDNAME$ $COMMAEXCEPTLAST$", $FOREACH FIELD END$
        "from $TABLENAME$",
        "where dr=0"
    })
    @Results({$FOREACH FIELD BEGIN$
        // $PROPERTYDESC$ 
        @Result(column="$FIELDNAME$", property="$PROPERTYNAME$", jdbcType=JdbcType.$PROPERTYDATATYPE$ $IDRESULTTAG$) $COMMAEXCEPTLAST$ $FOREACH FIELD END$
    })
    List<$ENTITYNAME$Entity> selectAll();
$HASBIZKEY BEGIN$
$IF BIZKEYCONTAINVARCHAR$
    @Select({
        "select",$FOREACH FIELD BEGIN$
        // $PROPERTYDESC$ 
        "$FIELDNAME$ $COMMAEXCEPTLAST$",$FOREACH FIELD END$
        "from $TABLENAME$",
        "where dr=0 and (1=2$BIZKEYWHERECONDITION$)"
    })
    @Results({$FOREACH FIELD BEGIN$
        // $PROPERTYDESC$ 
        @Result(column="$FIELDNAME$", property="$PROPERTYNAME$", jdbcType=JdbcType.VARCHAR $IDRESULTTAG$) $COMMAEXCEPTLAST$ $FOREACH FIELD END$
    })
    List<$ENTITYNAME$Entity> selectByBizKey(String bizKeyValue);
$ELSE$
    @Select({
        "select",$FOREACH FIELD BEGIN$
        // $PROPERTYDESC$ 
        "$FIELDNAME$ $COMMAEXCEPTLAST$",$FOREACH FIELD END$
        "from $TABLENAME$",
        "where dr=0 and (1=2$BIZKEYWHERECONDITION$)"
    })
    @Results({$FOREACH FIELD BEGIN$
        // $PROPERTYDESC$ 
        @Result(column="$FIELDNAME$", property="$PROPERTYNAME$", jdbcType=JdbcType.$PROPERTYDATATYPE$ $IDRESULTTAG$) $COMMAEXCEPTLAST$ $FOREACH FIELD END$
    })
    List<$ENTITYNAME$Entity> selectByBizKey($BIZKEYFIELDJAVATYPE$ bizKeyValue);$END IF$
$HASBIZKEY END$
    @Update({
        "update $TABLENAME$",
        "set",$FOREACH FIELD EXCEPT PK BEGIN$
        // $PROPERTYDESC$  $IFVERSION BEGIN$
        "$FIELDNAME$ = $FIELDNAME$ + 1 ,", $IFVERSION ELSE$ 
		"$FIELDNAME$ = #{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$} $COMMAEXCEPTLAST$", $IFVERSION END$  $FOREACH FIELD EXCEPT PK END$
        "where $PKFIELDNAME$ = #{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$}" $HASVERSION BEGIN$ ,
        " and version = #{version,jdbcType=INTEGER}" $HASVERSION END$ 
    })
    int updateByPrimaryKey($ENTITYNAME$Entity record);
}