package context;

import io.cucumber.java.Before;
import io.cucumber.java.Scenario;
import org.apache.logging.log4j.ThreadContext;

import java.util.HashMap;

public class Hooks {
    private final World world;

    public Hooks(World world) {
        this.world = world;
    }

    @Before(order = 0)
    public void doSetupBeforeExecution(Scenario scenario) {

        if (World.threadLocal.get()==null) {
            World.threadLocal.set(new HashMap<>());
        }
        world.featureContext = World.threadLocal.get();
        world.scenarioContext.put("scenario", scenario);
        ThreadContext.put("featureName", getFeatureFileNameFromScenarioId(scenario));
        ThreadContext.put("scenarioName", scenario.getName());
    }

    private String getFeatureFileNameFromScenarioId(Scenario scenario) {
        String scenarioId = scenario.getId();
//        int start = scenarioId.lastIndexOf("/") + 1;
//        int end = scenarioId.indexOf(".");
        return scenarioId;
    }
}
