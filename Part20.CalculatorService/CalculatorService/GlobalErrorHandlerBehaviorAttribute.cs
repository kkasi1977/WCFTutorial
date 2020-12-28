using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace CalculatorService
{
    public class GlobalErrorHandlerBehaviorAttribute : Attribute, IServiceBehavior
    {

        private readonly Type errorHandlerType;

        // CalculatorServie의 특성에서 GlobalErrorHandler의 Type을 파라미터로 넘겨 받는다.
        // 이 파라미터는 ApplyDispatchBehavior()에서 동작 함수 구현에 적용한다.
        public GlobalErrorHandlerBehaviorAttribute(Type errorHandlerType)
        {
            this.errorHandlerType = errorHandlerType;
        }




        #region IServiceBehavior 멤버

        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }

        /// <summary>
        /// 전역 오류 처리기로 연결하는 코드를 작성한다.
        /// 클래스 변수에 저장된 유형의 인스턴스를 생성하여 handler변수에 저장하고 
        /// 각 서비스 채널 디스패처를 반복 한 다음 해당 디스패처로 
        /// 오류 처리기 컬렉션 속성에 오류 처리기를 연결한다.
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            IErrorHandler handler = (IErrorHandler)Activator.CreateInstance(this.errorHandlerType);

            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                if (channelDispatcher != null)
                    channelDispatcher.ErrorHandlers.Add(handler);
            }
        }

        #endregion
    }
}
