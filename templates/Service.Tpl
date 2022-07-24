package $CLASSROOT$.service;

import $CLASSROOT$.entity.$ENTITYNAME$Entity;
import $CLASSROOT$.vo.$ENTITYNAME$VO;
$HASAGGVO BEGIN$
import jp.co.gutingjun.common.pms.entity.AggVO;
import $CLASSROOT$.vo.$ENTITYNAME$AggVO;$HASAGGVO END$

public interface $ENTITYNAME$Service {
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

    /**
     * 保存$ENTITYDESC$数据
     *
     * @param entity $ENTITYDESC$实体
     * @return 保存成功的$ENTITYDESC$ID
     */
    public Long save($ENTITYNAME$Entity entity);
$HASBIZKEY BEGIN$
    /**
    * 按业务主键取$ENTITYDESC$集合
    *
    * @param bizKey 业务主键
    * @return
    */
    public $ENTITYNAME$Entity[] get$ENTITYNAME$ByBizKey(Long bizKey);$HASBIZKEY END$
$HASAGGVO BEGIN$
    /**
    * 获取指定$ENTITYDESC$聚合VO对象
    *
    * @param id $ENTITYDESC$ID
    * @return $ENTITYDESC$聚合VO
    */
    public AggVO get$ENTITYNAME$AggVOByID(Long id);

    /**
    * 保存$ENTITYDESC$全档案
    *
    * @param aggVO $ENTITYDESC$聚合VO
    * @return
    */
    public Long save($ENTITYNAME$AggVO aggVO) throws Exception;
    $HASAGGVO END$
}
