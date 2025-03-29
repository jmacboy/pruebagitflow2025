package testrunner;

import context.World;
import io.cucumber.junit.Cucumber;
import io.cucumber.junit.CucumberOptions;
import org.junit.BeforeClass;
import org.junit.runner.RunWith;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.util.Collection;
import java.util.HashMap;
import java.util.Properties;

import static org.apache.commons.io.FileUtils.listFiles;

@RunWith(Cucumber.class)
@CucumberOptions(features = {"src/test/java/"},
        glue = {"."},
        //tags = "@Sanity",
        plugin = {"pretty"},
        monochrome = true
)
public class TestRunner {
    public static final String DEFAULT_ENV = "dev";
    private static final ThreadLocal<HashMap<String, Object>> FeatureContext = new ThreadLocal<>();
    public static Properties envConfig;
    public static String testEnv;

    @BeforeClass
    public static void runThisBeforeTestExecution() throws Exception {
        System.out.println("Runner class : JUnitRunner");
        testEnv = System.getProperty("env") == null ? DEFAULT_ENV : System.getProperty("env").toLowerCase();

        envConfig = new Properties();
        Collection<File> files = listFiles(new File(System.getProperty("user.dir") + "/src/test/java"), new String[]{"properties"}, true);
        for (File file : files) {
            if (file.getAbsolutePath().endsWith(testEnv + File.separator + "config.properties") || file.getAbsolutePath().endsWith("common" + File.separator + "config.properties")) {
                try {
                    envConfig.load(Files.newInputStream(file.toPath()));
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
        envConfig.list(System.out);

        World.envConfig = envConfig;
        World.threadLocal = FeatureContext;
    }
}
