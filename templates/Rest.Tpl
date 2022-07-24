package $CLASSROOT$.rest;

import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;
import jp.co.gutingjun.common.util.BaseRest;
import jp.co.gutingjun.common.util.R;
import $CLASSROOT$.entity.$ENTITYNAME$Entity;
import $CLASSROOT$.rest.request.IDRequest;
import $CLASSROOT$.vo.$ENTITYNAME$VO;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import $CLASSROOT$.service.*;
$HASAGGVO BEGIN$
import jp.co.gutingjun.common.pms.entity.AggVO;
import $CLASSROOT$.rest.request.$ENTITYNAME$AggVORequest;
import $CLASSROOT$.vo.$ENTITYNAME$AggVO;$HASAGGVO END$

/**
 * $ENTITYDESC$接口
 *
 * @author $AUTHOR$
 * @create $DATE$
 */
@RestController
@Slf4j
@Api(
    value = "pms rest",
    tags = {"pms"})
@RequestMapping("pms")
public class $ENTITYNAME$Rest extends BaseRest {
  @Autowired $ENTITYNAME$Service $LOWER_ENTITYNAME$Service;

  @ApiOperation(value = "/$ENTITYNAME_LOWER$", notes = "$ENTITYDESC$数据加载")
  @PostMapping(value = "/$ENTITYNAME_LOWER$")
  @ResponseBody
  public R<$ENTITYNAME$VO[]> load$ENTITYNAME$() {
    return R.responseBySuccess($LOWER_ENTITYNAME$Service.getAll$ENTITYNAME$());
  }

  @ApiOperation(value = "/$ENTITYNAME_LOWER$byid", notes = "指定$ENTITYDESC$数据加载")
  @PostMapping(value = "/$ENTITYNAME_LOWER$byid")
  @ResponseBody
  public R<$ENTITYNAME$VO> load$ENTITYNAME$ByID(@RequestBody IDRequest request) {
    return R.responseBySuccess($LOWER_ENTITYNAME$Service.get$ENTITYNAME$ByID(request.getId()));
  }

  @ApiOperation(value = "/$ENTITYNAME_LOWER$save", notes = "$ENTITYDESC$数据保存")
  @PostMapping(value = "/$ENTITYNAME_LOWER$save")
  @ResponseBody
  public R<Long> save(@RequestBody $ENTITYNAME$Entity request) {
    return R.responseBySuccess($LOWER_ENTITYNAME$Service.save(request));
  }
$HASAGGVO BEGIN$
  @ApiOperation(value = "/$ENTITYNAME_LOWER$byparentid", notes = "指定$ENTITYDESC$聚合数据加载")
  @PostMapping(value = "/$ENTITYNAME_LOWER$byparentid")
  @ResponseBody
  public R<AggVO> load$ENTITYNAME$AggVOByID(@RequestBody IDRequest request) {
    return R.responseBySuccess($LOWER_ENTITYNAME$Service.get$ENTITYNAME$AggVOByID(request.getId()));
  }

  @ApiOperation(value = "/$ENTITYNAME_LOWER$aggsave", notes = "$ENTITYDESC$数据保存")
  @PostMapping(value = "/$ENTITYNAME_LOWER$aggsave")
  @ResponseBody
  public R<Long> save(@RequestBody $ENTITYNAME$AggVORequest request) {
    $ENTITYNAME$AggVO aggVO = new $ENTITYNAME$AggVO();
    aggVO.setParent(request.getParent());$FOREACH AGG VO BEGIN$
    aggVO.set$PROPERTYVODATATYPE$(request.get$PROPERTYVODATATYPE$());$FOREACH AGG VO END$
    try{
      Long rtn = $LOWER_ENTITYNAME$Service.save(aggVO);
      return R.responseBySuccess(rtn);
    }catch (Exception ex){
      return R.responseByError(0, ex.getMessage());
    }
  }
$HASAGGVO END$
}