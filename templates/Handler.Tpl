package $CLASSROOT$.service.handler.$ENTITYNAME_LOWER$;

import $CLASSROOT$.service.handler.AbstractHandler;
import $CLASSROOT$.service.handler.IRule;
$IF HASAGGVO$import $CLASSROOT$.vo.$ENTITYNAME$AggVO;$ELSE$import $CLASSROOT$.vo.$ENTITYNAME$VO;$END IF$
import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.annotation.*;
import org.springframework.stereotype.Component;

@Aspect
@Component
/**
 * $ENTITYDESC$保存前后事件增强处理器
 *
 * @author $AUTHOR$
 * @since $DATE$
 */
public class $ENTITYNAME$SaveHandler extends AbstractHandler {
  @Pointcut("execution(public * $CLASSROOT$.service.impl.$ENTITYNAME$ServiceImpl.save(..))")
  // 切入点签名
  public void log() {
    System.out.println("$ENTITYNAME$ Pointcut");
  }
  // 前置处理
  @Before("log()")
  public void beforeHandler(JoinPoint jp) throws Throwable {
    for (IRule ruleBean : getRegisterRules()) {
      ruleBean.doBefore(jp.getArgs());
    }
  }
  // 返回处理
  @AfterReturning(returning = "ret", pointcut = "log()")
  public void afterReturnHanlder(Object ret) throws Throwable {
    for (IRule ruleBean : getRegisterRules()) {
      ruleBean.doAfterReturn(ret);
    }
  }

  // 异常处理
  @AfterThrowing(throwing = "ex", pointcut = "log()")
  public void throwsHandler(JoinPoint jp, Exception ex) {
    System.out.println("$ENTITYNAME$ Pointcut: throwsHandler");
  }

  // 后置处理
  @After("log()")
  public void afterHandler(JoinPoint jp) {
    for (IRule ruleBean : getRegisterRules()) {
      ruleBean.doAfter(jp.getArgs());
    }
  }

  @Override
  public Class getHostVOType() {
    return $ENTITYNAME$$IF HASAGGVO$AggVO$ELSE$VO$END IF$.class;
  }
}