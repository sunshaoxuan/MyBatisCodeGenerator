DROP PROCEDURE if exists add_tbl_column;
DELIMITER $$
CREATE PROCEDURE add_tbl_column()
	BEGIN
        CREATE TABLE IF NOT EXISTS $TABLENAME$_res (
	    `id` bigint  NOT NULL COMMENT '主键',
	    `lang` varchar(2)  NOT NULL COMMENT '语言',
         PRIMARY KEY (`$PKFIELDNAME$`, `lang`)
        ) COMMENT='$ENTITYDESC$多语';
        $FOREACH MULTILANG FIELD BEGIN$
        IF NOT EXISTS( SELECT NULL
                    FROM INFORMATION_SCHEMA.COLUMNS
                   WHERE table_name = '$TABLENAME$_res'
                     AND table_schema = '$DATABASENAME$'
                     AND column_name = '$FIELDNAME$')  THEN
          ALTER TABLE $TABLENAME$_res ADD $FIELDNAME$ $FIELDDATATYPE$ $CHARACTERTAG$ $DEFAULTTAG$ COMMENT '$PROPERTYDESC$';
        END IF;
        $FOREACH MULTILANG FIELD END$
        IF NOT EXISTS( SELECT NULL
                    FROM INFORMATION_SCHEMA.COLUMNS
                   WHERE table_name = '$TABLENAME$_res'
                     AND table_schema = '$DATABASENAME$'
                     AND column_name = 'dr')  THEN
          ALTER TABLE $TABLENAME$_res ADD dr tinyint default 0 COMMENT '删除标志';
        END IF;
	END$$
DELIMITER ;
CALL add_tbl_column() ;
DROP PROCEDURE add_tbl_column ;