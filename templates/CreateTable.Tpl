DROP PROCEDURE if exists add_tbl_column;
DELIMITER $$
CREATE PROCEDURE add_tbl_column()
	BEGIN
        CREATE TABLE IF NOT EXISTS $TABLENAME$ (
          $PKFIELDNAME$ bigint  NOT NULL COMMENT '主键',
          PRIMARY KEY ($PKFIELDNAME$)
        ) COMMENT='$ENTITYDESC$';
        $FOREACH FIELD BEGIN$
        IF NOT EXISTS( SELECT NULL
                    FROM INFORMATION_SCHEMA.COLUMNS
                   WHERE table_name = '$TABLENAME$'
                     AND table_schema = '$DATABASENAME$'
                     AND column_name = '$FIELDNAME$')  THEN
          ALTER TABLE $TABLENAME$ ADD $FIELDNAME$ $FIELDDATATYPE$ $CHARACTERTAG$ $DEFAULTTAG$;
        END IF;$FOREACH FIELD END$
	END$$
DELIMITER ;
CALL add_tbl_column() ;
DROP PROCEDURE add_tbl_column ;