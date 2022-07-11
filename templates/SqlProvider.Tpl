package $SQLPROVIDERNAMESPACE$;

import $SQLPROVIDERNAMESPACE$.$ENTITYNAME$EntitySqlProvider;
import $ENTITYNAMESPACE$.$ENTITYNAME$Entity;
import org.apache.ibatis.jdbc.SQL;

/**
 * $ENTITYDESC$ Sql Provider
 *
 * @author $AUTHOR$
 * @since $DATE$
 */
public class $ENTITYNAME$EntitySqlProvider {

    public String insertSelective($ENTITYNAME$Entity record) {
        SQL sql = new SQL();
        sql.INSERT_INTO("$TABLENAME$");
$FOREACH FIELD BEGIN$
        /** $PROPERTYDESC$ */
        if (record.$PROPERTYGETMETHOD$() != null) {
            sql.VALUES("$FIELDNAME$", "#{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$}");
        }

$FOREACH FIELD END$
        return sql.toString();
    }

    public String updateByPrimaryKeySelective($ENTITYNAME$Entity record) {
        SQL sql = new SQL();
        sql.UPDATE("$TABLENAME$");
$FOREACH FIELD EXCEPT PK BEGIN$
        /** $PROPERTYDESC$ */
        if (record.$PROPERTYGETMETHOD$() != null) {
            sql.SET("$FIELDNAME$ = #{$PROPERTYNAME$,jdbcType=$PROPERTYDATATYPE$}");
        }
$FOREACH FIELD EXCEPT PK END$
        sql.WHERE("$PKFIELDNAME$ = #{$PKPROPERTYNAME$,jdbcType=$PKFIELDDATATYPE$}");
        
        return sql.toString();
    }
}