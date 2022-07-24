package $CLASSROOT$.dao.provider;

import $CLASSROOT$.dao.provider.$ENTITYNAME$ResEntitySqlProvider;
import $CLASSROOT$.entity.$ENTITYNAME$ResEntity;
import org.apache.ibatis.jdbc.SQL;

/**
 * $ENTITYDESC$ Sql Provider
 *
 * @author $AUTHOR$
 * @since $DATE$
 */
public class $ENTITYNAME$ResEntitySqlProvider {

    public String insertSelective($ENTITYNAME$ResEntity record) {
        SQL sql = new SQL();
        sql.INSERT_INTO("$TABLENAME$_res");

        /** 主键 */
        if (record.getId() != null) {
          sql.VALUES("$PKFIELDNAME$", "#{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$}");
        }

        /** 语言 */
        if (record.getLang() != null) {
          sql.VALUES("lang", "#{lang,jdbcType=JdbcType.VARCHAR}");
        }

        /** 更新时间 */
        if (record.getUpdatedTime() != null) {
          sql.VALUES("update_time", "#{updateTime,jdbcType=JdbcType.TIMESTAMP}");
        }

$FOREACH MULTILANG PROPERTY BEGIN$
        /** $PROPERTYDESC$ */
        if (record.$PROPERTYGETMETHOD$() != null) {
            sql.VALUES("$FIELDNAME$", "#{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$}");
        }

$FOREACH MULTILANG PROPERTY END$
        return sql.toString();
    }

    public String updateByPrimaryKeySelective($ENTITYNAME$ResEntity record) {
        SQL sql = new SQL();
        sql.UPDATE("$TABLENAME$_res");
$FOREACH MULTILANG PROPERTY BEGIN$
        /** $PROPERTYDESC$ */
        if (record.$PROPERTYGETMETHOD$() != null) {
            sql.SET("$FIELDNAME$ = #{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$}");
        }
$FOREACH MULTILANG PROPERTY END$

        /** 更新时间 */
        if (record.getUpdatedTime() != null) {
          sql.SET("updated_time = #{updatedTime,jdbcType=JdbcType.TIMESTAMP}");
        }

        sql.WHERE("$PKFIELDNAME$ = #{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$} and lang = #{lang,jdbcType=JdbcType.VARCHAR}");
        
        return sql.toString();
    }
}
