using Elements;
using Elements.Geometry;
using System.Collections.Generic;

namespace ScopeVisibility
{
    public static class ScopeVisibility
    {
        /// <summary>
        /// The ScopeVisibility function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A ScopeVisibilityOutputs instance containing computed results and the model with any new elements.</returns>
        public static ScopeVisibilityOutputs Execute(Dictionary<string, Model> inputModels, ScopeVisibilityInputs input)
        {
            var output = new ScopeVisibilityOutputs();

            BBox3 bbox = new BBox3((-100, -100, -100), (100, 100, 100));
            var vs = new ViewScope()
            {
                BoundingBox = bbox,
                Camera = new Camera(default, CameraNamedPosition.Top, CameraProjection.Orthographic),
                Name = "Function Generated View",
                LockRotation = true,
                ClipWithBoundingBox = false,
                FunctionVisibility = new Dictionary<string, string>() {
                  { "Envelope", "visible" },
                  { "Facade", "hidden" },
                  { "Levels", "hidden" } }, // hidden, visible, context, isolated, isolatedInContext
                Modal = false,
            };

            output.Model.AddElement(vs);
            return output;
        }
    }
}