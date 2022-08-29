package $CLASSROOT$.inf;

import $CLASSROOT$.vo.$ENTITYNAME$VO;
$HASAGGVO BEGIN$
import $CLASSROOT$.vo.aggvo.AggVO;
import $CLASSROOT$.vo.aggvo.$ENTITYNAME$AggVO;$HASAGGVO END$

public interface I$ENTITYNAME$Service {
    /**
     * 取所有$ENTITYDESC$数据
     *
     * @return $ENTITYDESC$数据集合
     */
    public $ENTITYNAME$VO[] getAll$ENTITYNAME$();
    
    /**
     * 获取指定$ENTITYDESC$数据
     * @return 指定$ENTITYDESC$数据
     */
    public $ENTITYNAME$VO get$ENTITYNAME$ByID(Long id);
$IF HASAGGVO$
    /**
    * 获取指定$ENTITYDESC$聚合VO对象
    *
    * @param id $ENTITYDESC$ID
    * @return $ENTITYDESC$聚合VO
    */
    public AggVO get$ENTITYNAME$AggVOByID(Long id);

    /**
     * 获取指定$ENTITYDESC$及语言的聚合VO对象
     *
     * @param id $ENTITYDESC$ID
     * @param lang 语言
     * @return $ENTITYDESC$聚合VO
     */
    public AggVO get$ENTITYNAME$AggVOByIDLang(Long id, String lang);

    /**
    * 保存$ENTITYDESC$全档案
    *
    * @param aggVO $ENTITYDESC$聚合VO
    * @return
    */
    public $ENTITYNAME$AggVO save($ENTITYNAME$AggVO aggVO) throws Exception;

    /**
     * 删除$ENTITYDESC$全档案
     *
     * @param aggVO 房源信息聚合
     * @return 成功标记，0不成功，1成功
     * @throws Exception
     */
    public Integer delete($ENTITYNAME$AggVO aggVO) throws Exception;
$ELSE$
    /**
     * 保存$ENTITYDESC$数据
     *
     * @param vo $ENTITYDESC$VO
     * @return $ENTITYDESC$ID
     */
    public Long save($ENTITYNAME$VO vo) throws Exception;
    
    /**
     * 删除指定$ENTITYDESC$记录
     *
     * @param vo $ENTITYDESC$VO
     * @return 成功标记，0不成功，1成功
     */
    public Integer delete($ENTITYNAME$VO vo) throws Exception;$END IF$
$HASBIZKEY BEGIN$ $IF BIZKEYCONTAINVARCHAR$
    /**
    * 按业务主键取$ENTITYDESC$集合
    *
    * @param bizKey 业务主键
    * @return
    */
    public $ENTITYNAME$VO[] get$ENTITYNAME$ByBizKey(String bizKey);
$ELSE$
    /**
    * 按业务主键取$ENTITYDESC$集合
    *
    * @param bizKey 业务主键
    * @return
    */
    public $ENTITYNAME$VO[] get$ENTITYNAME$ByBizKey(Long bizKey);$END IF$ $HASBIZKEY END$
}
