﻿using System.IO;

public class GitIgnore {
    private const string gitignore =
        "Modified gitignore from https://github.com/github/gitignore/blob/main/Unity.gitignore\n" +
        "\n" +
        "/[Ll]ibrary/\n" +
        "/[Tt]emp/\n" +
        "/[Oo]bj/\n" +
        "/[Bb]uild/\n" +
        "/[Bb]uilds/\n" +
        "/[Ll]ogs/\n" +
        "/[Uu]ser[Ss]ettings/\n" +
        "\n" +
        "# MemoryCaptures can get excessive in size.\n" +
        "# They also could contain extremely sensitive data\n" +
        "/[Mm]emoryCaptures/\n" +
        "\n" +
        "# Recordings can get excessive in size\n" +
        "/[Rr]ecordings/\n" +
        "\n" +
        "# Uncomment this line if you wish to ignore the asset store tools plugin\n" +
        "# /[Aa]ssets/AssetStoreTools*\n" +
        "\n" +
        "# Autogenerated Jetbrains Rider plugin\n" +
        "/[Aa]ssets/Plugins/Editor/JetBrains*\n" +
        ".idea/\n" +
        "\n" +
        "# Visual Studio cache directory\n" +
        ".vs/\n" +
        "\n" +
        "# Gradle cache directory\n" +
        ".gradle/\n" +
        "\n" +
        "# Plastic\n" +
        ".plastic/\n" +
        "\n" +
        "# Autogenerated VS/MD/Consulo solution and project files\n" +
        "ExportedObj/\n" +
        ".consulo/\n" +
        "*.csproj\n" +
        "*.unityproj\n" +
        "*.sln\n" +
        "*.suo\n" +
        "*.tmp\n" +
        "*.user\n" +
        "*.userprefs\n" +
        "*.pidb\n" +
        "*.booproj\n" +
        "*.svd\n" +
        "*.pdb\n" +
        "*.mdb\n" +
        "*.opendb\n" +
        "*.VC.db\n" +
        "\n" +
        "# Unity3D generated meta files\n" +
        "*.pidb.meta\n" +
        "*.pdb.meta\n" +
        "*.mdb.meta\n" +
        "\n" +
        "# Unity3D generated file on crash reports\n" +
        "sysinfo.txt\n" +
        "\n" +
        "# Builds\n" +
        "*.apk\n" +
        "*.aab\n" +
        "*.unitypackage\n" +
        "*.app\n" +
        "\n" +
        "# Crashlytics generated file\n" +
        "crashlytics-build.properties\n" +
        "\n" +
        "# Packed Addressables\n" +
        "/[Aa]ssets/[Aa]ddressable[Aa]ssets[Dd]ata/*/*.bin*\n" +
        "\n" +
        "# Temporary auto-generated Android Assets\n" +
        "/[Aa]ssets/[Ss]treamingAssets/aa.meta\n" +
        "/[Aa]ssets/[Ss]treamingAssets/aa/*";

    public static void CreteDefaultGitIgnore(string projectDirectory) {
        if (!File.Exists(Path.Combine(projectDirectory, ".gitignore"))) {
            string gitIgnorePath = Path.Combine(projectDirectory, ".gitignore");
            File.WriteAllText(gitIgnorePath, gitignore);
        }
    }
}