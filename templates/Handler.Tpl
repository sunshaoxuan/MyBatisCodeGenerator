package $CLASSROOT$.impl.handler.$ENTITYNAME_LOWER$;

import $CLASSROOT$.impl.handler.AbstractHandler;
import $CLASSROOT$.impl.handler.IRule;
$IF HASAGGVO$import $CLASSROOT$.vo.aggvo.$ENTITYNAME$AggVO;$ELSE$import $CLASSROOT$.vo.$ENTITYNAME$VO;$END IF$
import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.annotation.*;
import org.springframework.stereotype.Component;

@Aspect
@Component
/**
 * $ENTITYDESC$$HANDLERTYPENAME$前后事件增强处理器
 *
 * @author $AUTHOR$
 * @since $DATE$
 */
public class $ENTITYNAME$$HANDLERTYPE$Handler extends AbstractHandler {
  @Pointcut("execution(public * $CLASSROOT$.impl.$ENTITYNAME$ServiceImpl.$LOWER_HANDLERTYPE$(..))")
  // 切入点签名
  public void log() {
    System.out.println("$ENTITYNAME$ Pointcut");
  }
  // 前置处理
  @Before("log()")
  public void beforeHandler(JoinPoint jp) throws Exception {
    getRegisterRules()
        .forEach(
            ruleBean -> {
              try {
                ruleBean.doBeforeCheck(jp.getArgs());
                ruleBean.doBefore(jp.getArgs());
              } catch (Exception e) {
                throw new RuntimeException(e.getMessage());
              }
            });
  }
  // 返回处理
  @AfterReturning(returning = "ret", pointcut = "log()")
  public void afterReturnHanlder(Object ret) throws Exception {
    getRegisterRules()
        .forEach(
            ruleBean -> {
              ruleBean.doAfterReturn(ret);
            });
  }

  // 异常处理
  @AfterThrowing(throwing = "ex", pointcut = "log()")
  public void throwsHandler(JoinPoint jp, Exception ex) {
    System.out.printf("$ENTITYNAME$ Pointcut: %s%n", ex.getMessage());
  }

  // 后置处理
  @After("log()")
  public void afterHandler(JoinPoint jp) throws Exception {
    getRegisterRules()
        .forEach(
            ruleBean -> {
              try {
                ruleBean.doAfterCheck(jp.getArgs());
                ruleBean.doAfter(jp.getArgs());
              } catch (Exception e) {
                throw new RuntimeException(e.getMessage());
              }
            });
  }

  @Override
  public Class getHostVOType() {
    return $ENTITYNAME$$IF HASAGGVO$AggVO$ELSE$VO$END IF$.class;
  }
}