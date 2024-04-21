window.registerUnloadEvent = function () {
  window.onbeforeunload = function () {
    DotNet.invokeMethodAsync(
      "RecipeRepository",
      "DisposeImage",
      document.getElementById("image").value
    );
  };
};
