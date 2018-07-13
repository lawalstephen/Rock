// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//

using Quartz;
using Rock.Attribute;
using Rock.Cache;
using Rock.Utility;
using Rock.Web;

namespace Rock.Jobs
{
    /// <summary>
    /// Job to process NCOA results
    /// </summary>
    [DefinedValueField(Rock.SystemGuid.DefinedType.PERSON_RECORD_STATUS_REASON, "Inactive Reason", 
        "The reason to use when inactivating people due to moving beyond the configured number of miles.", true, false, 
        Rock.SystemGuid.DefinedValue.PERSON_RECORD_STATUS_REASON_MOVED, "", 0 )]
    [DisallowConcurrentExecution]
    public class ProcessNcoaResults : IJob
    {
        /// <summary> 
        /// Empty constructor for job initialization
        /// <para>
        /// Jobs require a public empty constructor so that the
        /// scheduler can instantiate the class whenever it needs.
        /// </para>
        /// </summary>
        public ProcessNcoaResults()
        {
        }

        /// <summary>
        /// Executes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void Execute( IJobExecutionContext context )
        {
            // Get the inactive reason
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            var inactiveReason = CacheDefinedValue.Get( dataMap.GetString( "InactiveReason" ).AsGuid() );

            var minMoveDistance = SystemSettings.GetValue( SystemKey.SystemSetting.NCOA_MINIMUM_MOVE_DISTANCE_TO_INACTIVATE ).AsDecimalOrNull();

            // Process the 'None' and 'NoMove' NCOA Types (these will always have an address state as 'invalid')
            var markInvalidAsPrevious = SystemSettings.GetValue( SystemKey.SystemSetting.NCOA_SET_INVALID_AS_PREVIOUS ).AsBoolean();

            // Process the '48 Month Move' NCOA Types
            var mark48MonthAsPrevious = SystemSettings.GetValue( SystemKey.SystemSetting.NCOA_SET_48_MONTH_AS_PREVIOUS ).AsBoolean();

            Ncoa ncoa = new Ncoa();
            ncoa.ProcessNcoaResults( inactiveReason, markInvalidAsPrevious, mark48MonthAsPrevious, minMoveDistance );
        }
    }
}
