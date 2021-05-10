using System;
using Xunit;

namespace CSharp6Features.Tests.ExceptionFilters
{
    public class ExceptionFiltersTests
    {
        [Fact]
        public void ExceptionIsCaughtByMatchedFilter()
        {
            try
            {
                throw new Exception("Error 1205: Transaction (Process ID %d) was deadlocked on %.*ls resources with another process and has been chosen as the deadlock victim. Rerun the transaction.");
            }
            catch (Exception e) when (e.Message.StartsWith("Error 1203:"))
            {
                Assert.StartsWith("Error 1203:", e.Message);
            }
            catch (Exception e) when (e.Message.StartsWith("Error 1205:"))
            {
                Assert.StartsWith("Error 1205:", e.Message);
            }
            catch (Exception e)
            {
                Assert.False(e.Message.StartsWith("Error 1203:"));
                Assert.False(e.Message.StartsWith("Error 1205:"));
            }
        }

        [Fact]
        public void ExceptionIsCaughtByFilterlessBlockWhenNoFilterMatches()
        {
            try
            {
                throw new Exception("Error 1206: The Microsoft Distributed Transaction Coordinator (MS DTC) has cancelled the distributed transaction.");
            }
            catch (Exception e) when (e.Message.StartsWith("Error 1203:"))
            {
                Assert.StartsWith("Error 1203:", e.Message);
            }
            catch (Exception e) when (e.Message.StartsWith("Error 1205:"))
            {
                Assert.StartsWith("Error 1205:", e.Message);
            }
            catch (Exception e)
            {
                Assert.False(e.Message.StartsWith("Error 1203:"));
                Assert.False(e.Message.StartsWith("Error 1205:"));
            }
        }
    }
}
