// import React, { useState, useEffect } from 'react';
//
//
// const CountdownTimer = ({ slaExpiredOn }: { slaExpiredOn: Date }) => {
//     const [counter, setCounter] = useState<number>(0);
//     const [updateFlag, setUpdateFlag] = useState<boolean>(false);
//
//     useEffect(() => {
//         if (slaExpiredOn) {
//             const interval = setInterval(() => {
//                 const now = new Date();
//                 const timeDiff = slaExpiredOn.getTime() - now.getTime();
//
//                 if (timeDiff > 0) {
//                     const seconds = Math.floor(timeDiff / 1000);
//                     setCounter(seconds);
//                 } else {
//                     setCounter(0);
//                     setUpdateFlag(true);
//                 }
//             }, 1000);
//
//             return () => {
//                 clearInterval(interval);
//             };
//         }
//
//     }, [slaExpiredOn]);
//
//     if (counter === 0) {
//         return <>
//             <div>Expired 😫</div>
//         </>
//     }
//
//     return (
//         <div>
//             <p>Countdown: {counter} seconds</p>
//             {updateFlag && <p>Update flag: expired</p>}
//         </div>
//     );
// }
//
// export default CountdownTimer;


import React, { useState, useEffect } from 'react';

interface Request {
    // Your existing interface properties
    // ...
    slaExpiredOn: Date | string;
    // ...
}

function CountdownTimer({ slaExpiredOn }: { slaExpiredOn: Date | string }) {
    const [counter, setCounter] = useState<number>(0);

    useEffect(() => {
        if (typeof slaExpiredOn === 'string') {
            slaExpiredOn = new Date(slaExpiredOn);
        }

        const interval = setInterval(() => {
            const now = new Date();
            // @ts-ignore
            const timeDiff = slaExpiredOn.getTime() - now.getTime();

            if (timeDiff > 0) {
                const seconds = Math.floor(timeDiff / 1000);
                setCounter(seconds);
            } else {
                setCounter(0);
            }
        }, 1000);

        return () => {
            clearInterval(interval);
        };
    }, [slaExpiredOn]);

    if (counter === 0) {
        return <>
            <div>Expired 😫</div>
        </>
    }
    return (
        <div>
            <p>Countdown: {counter} seconds</p>
        </div>
    );

}

export default CountdownTimer;