package $CLASSROOT$.rest;

import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;
import jp.co.gutingjun.common.util.BaseRest;
import jp.co.gutingjun.common.util.R;
import jp.co.gutingjun.pms.common.CommonUtils;
import $CLASSROOT$.rest.dto.*;
import $CLASSROOT$.vo.*;$HASAGGVO BEGIN$
import $CLASSROOT$.vo.aggvo.*;$HASAGGVO END$
import $CLASSROOT$.inf.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import lombok.extern.slf4j.Slf4j;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

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
  @Autowired I$ENTITYNAME$Service $LOWER_ENTITYNAME$Service;

  @ApiOperation(value = "$ENTITYDESC$数据加载", notes = "$ENTITYDESC$数据加载")
  @PostMapping(value = "/$ENTITYNAME_LOWER$")
  @ResponseBody
  public R load$ENTITYNAME$() {
    try {
      $ENTITYNAME$VO[] allVOs = $LOWER_ENTITYNAME$Service.getAll$ENTITYNAME$();
      List<$ENTITYNAME$DTO> allDTOs = new ArrayList<>();
      if (allVOs != null && allVOs.length > 0) {
        Arrays.stream(allVOs)
            .forEach(
                vo -> {
                  $ENTITYNAME$DTO dto = new $ENTITYNAME$DTO();
                  CommonUtils.vo2dto(vo, dto);
                  allDTOs.add(dto);
                });
      }
      return R.responseBySuccess(allDTOs.toArray(new $ENTITYNAME$VO[0]));
    } catch (Exception ex) {
      return R.responseByError(500, ex.getMessage());
    }
  }
$IF HASAGGVO$
$SKIP BEGIN$
  @ApiOperation(value = "指定$ENTITYDESC$聚合数据加载", notes = "指定$ENTITYDESC$聚合数据加载")
  @PostMapping(value = "/$ENTITYNAME_LOWER$byparentid")
  @ResponseBody
  public R<AggVO> load$ENTITYNAME$AggVOByID(@RequestBody IDDTO request) {
    return R.responseBySuccess($LOWER_ENTITYNAME$Service.get$ENTITYNAME$AggVOByID(request.getId()));
  }
$SKIP END$
  @ApiOperation(value = "指定$ENTITYDESC$聚合数据加载（可选语言）", notes = "指定$ENTITYDESC$聚合数据加载（可选语言，语种留空则为全语言）")
  @PostMapping(value = "/$ENTITYNAME_LOWER$byparentid")
  @ResponseBody
  public R load$ENTITYNAME$AggVOByID(@RequestBody LanguageDTO request) {
    try{
        AggVO aggVO = $LOWER_ENTITYNAME$Service.get$ENTITYNAME$AggVOByIDLang(request.getId(), request.getLang());
        $ENTITYNAME$AggDTO aggDTO = new $ENTITYNAME$AggDTO();
        CommonUtils.vo2dto(aggVO, aggDTO);
        return R.responseBySuccess(aggDTO);
    }catch(Exception ex){
        return R.responseByError(500, ex.getMessage());
    }
  }

  @ApiOperation(value = "$ENTITYDESC$数据保存", notes = "$ENTITYDESC$数据保存")
  @PostMapping(value = "/$ENTITYNAME_LOWER$aggsave")
  @ResponseBody
  public R<Long> save(@RequestBody $ENTITYNAME$AggDTO request) {
    $ENTITYNAME$AggVO aggVO = new $ENTITYNAME$AggVO();
    CommonUtils.dto2vo(request, aggVO);
    try{
      $ENTITYNAME$AggVO rtn = $LOWER_ENTITYNAME$Service.save(aggVO);
      return R.responseBySuccess(rtn.pickParentID());
    }catch (Exception ex){
      return R.responseByError(500, ex.getMessage());
    }
  }

  @ApiOperation(value = "$ENTITYDESC$数据删除", notes = "$ENTITYDESC$数据删除")
  @PostMapping(value = "/$ENTITYNAME_LOWER$aggdelete")
  @ResponseBody
  public R<Integer> delete(@RequestBody IDDTO request){
    $ENTITYNAME$AggVO aggVO = new $ENTITYNAME$AggVO();

    try{
      aggVO.loadByParentID(request.getId());
      return R.responseBySuccess(aggVO.delete(null));
    }catch (Exception ex){
      return R.responseByError(500, ex.getMessage());
    }
  }
$ELSE$
  @ApiOperation(value = "指定$ENTITYDESC$数据加载", notes = "指定$ENTITYDESC$数据加载")
  @PostMapping(value = "/$ENTITYNAME_LOWER$byid")
  @ResponseBody
  public R load$ENTITYNAME$ByID(@RequestBody IDDTO request) {
    try {
      $ENTITYNAME$VO vo = $LOWER_ENTITYNAME$Service.get$ENTITYNAME$ByID(request.getId());
      $ENTITYNAME$DTO dto = new $ENTITYNAME$DTO();
      CommonUtils.vo2dto(vo, dto);
      return R.responseBySuccess(dto);
    } catch (Exception ex) {
      return R.responseByError(500, ex.getMessage());
    }
  }

  @ApiOperation(value = "$ENTITYDESC$数据保存", notes = "$ENTITYDESC$数据保存")
  @PostMapping(value = "/$ENTITYNAME_LOWER$save")
  @ResponseBody
  public R<Long> save(@RequestBody $ENTITYNAME$DTO request) {
   $ENTITYNAME$VO newVO = new $ENTITYNAME$VO();
    CommonUtils.dto2vo(request, newVO);
    try {
      return R.responseBySuccess($LOWER_ENTITYNAME$Service.save(newVO));
    } catch (Exception ex) {
      return R.responseByError(500, ex.getMessage());
    }
  }

  @ApiOperation(value = "$ENTITYDESC$数据删除", notes = "$ENTITYDESC$数据删除")
  @PostMapping(value = "/$ENTITYNAME_LOWER$delete")
  @ResponseBody
  public R<Integer> delete(@RequestBody IDDTO request) {
    try {
      $ENTITYNAME$VO vo = new $ENTITYNAME$VO(request.getId());
      return R.responseBySuccess(vo.delete(null));
    } catch (Exception ex) {
      return R.responseByError(500, ex.getMessage());
    }
  }
$END IF$
}