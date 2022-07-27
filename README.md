# UTF Demo

This is a demo on how to use the Unity Test Framework package from Unity - [com.unity.test-framework@2.0](https://docs.unity3d.com/Packages/com.unity.test-framework@2.0/manual/index.html)
> At the moment, version 2.0 of UTF is available as a pre-release version. Therefore. I keep the repository with the latest fully supported version 1.1.33. 


## Quick Start Guide
1. How to use it
2. Clone the project
3. Open it with your editor version. I recently upgraded it to 2021.3.7f1 - prior that it was on 2020.3.x. So, it could probably be backwards compatible.
4. Based on your ticket edit the PlayMode or EditorMode Tests.
5. Run the tests. Depending on the requirements use one of the following:
    1. **UTF in-editor UI**: Window -> General -> Test Runner
    2. **Batchmode**: Edit/Run the test.sh file in the root of the project folder.

## Notes
The project comes with some basic tests to demonstrate how to use it.
* Edit mode: Some maths tests
* Play mode: Contains more advanced stuff.
    * IPrebuildSetup demo
    * ITestRunCallback demo
    * Scene loading
    * Coroutines

## Project Structure
```
│   test.sh                         #Run tests from batchmode
├───Assets
│   ├───Scenes                      #Scene used to run play mode tests
│   │       Game1.unity
│   │       Game2.unity
│   │       Game3.unity
│   ├───Tests
│   │   ├───EditMode                #Configure your edit mode tests here
│   │   │       EditMode.asmdef
│   │   │       EditModeTests.cs
│   │   └───PlayMode                #Configure your play mode tests here
│   │           PlayMode.asmdef
│   │           PlayModeTests.cs
```
## Disclaimer
Although this project is developed by Unity employees, it is not officially supported by Unity.
