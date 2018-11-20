using CMS.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CMS
{
    public enum FlowMove { HOME, NEXT, BACK, LAST }

    public class FlowState
    {
        private readonly FlowsFlowFlowElement[] flowElements;
        private readonly int lastIndex;
        private IDictionary<int, IViewModel> flowElementViewModelCache = new Dictionary<int, IViewModel>();

        public int CurrentIndex { get; private set; }
        public bool IsFirstIndex { get { return CurrentIndex == 0; } }
        public bool IsLastIndex { get { return CurrentIndex == this.lastIndex; } }

        public FlowState(FlowsFlowFlowElement[] flowElements)
        {
            this.flowElements = flowElements;
            this.lastIndex = flowElements.Length - 1;
        }

        public IViewModel Move(FlowMove flowMove)
        {
            switch (flowMove)
            {
                case CMS.FlowMove.HOME:
                    this.CurrentIndex = 0;
                    break;

                case CMS.FlowMove.NEXT:
                    if (this.CurrentIndex < lastIndex)
                    {
                        this.CurrentIndex++;
                    }
                    break;

                case CMS.FlowMove.BACK:
                    if (this.CurrentIndex > 0)
                    {
                        this.CurrentIndex--;
                    }
                    break;

                case CMS.FlowMove.LAST:
                    this.CurrentIndex = lastIndex;
                    break;

                default:
                    this.CurrentIndex = 0;
                    break;
            }

            if (!flowElementViewModelCache.ContainsKey(CurrentIndex))
            {
                var flowElementViewModel = Activator.CreateInstance(Type.GetType(flowElements[CurrentIndex].FlowElementType)) as IViewModel;
                flowElementViewModelCache.Add(CurrentIndex, flowElementViewModel);
            }
            return flowElementViewModelCache[CurrentIndex];
        }
    }

    public sealed class FlowManager
    {
        private static readonly Lazy<FlowManager> lazy =
             new Lazy<FlowManager>(() => new FlowManager());

        private Flows flows;
        private IDictionary<string, FlowState> flowStateCache = new Dictionary<string, FlowState>();

        public IViewModel FlowMove(string flowName, FlowMove flowMove)
        {
            if (!flowStateCache.ContainsKey(flowName))
            {
                var flow = flows.Items.FirstOrDefault(f => f.Name.Equals(flowName));

                flowStateCache.Add(flowName, new FlowState(flow.FlowElement));
            }

            return flowStateCache[flowName].Move(flowMove);
        }

        public int GetFlowCurrentIndex(string flowName)
        {
            return flowStateCache[flowName].CurrentIndex;
        }

        public bool IsFlowAtFirstIndex(string flowName)
        {
            return flowStateCache[flowName].IsFirstIndex;
        }

        public bool IsFlowAtLastIndex(string flowName)
        {
            return flowStateCache[flowName].IsLastIndex;
        }

        public static FlowManager Instance { get { return lazy.Value; } }

        private FlowManager()
        {
            Initialize();
        }

        private void Initialize()
        {
            XmlSerializer ser = new XmlSerializer(typeof(Flows));
            using (XmlReader reader = XmlReader.Create("FlowConfiguration.xml"))
            {
                flows = (Flows)ser.Deserialize(reader);
            }

        }
    }

}
