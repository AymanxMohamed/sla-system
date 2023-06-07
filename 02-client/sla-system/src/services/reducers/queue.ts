import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import Queue from "../types/Api/Entities/Queue";

const queueSlice = createSlice({
    name: "queue",
    initialState: [] as Queue[],
    reducers: {
        setQueues(state, action: PayloadAction<Queue[]>) {
            state = action.payload;
        },
        addQueue(state, action: PayloadAction<Queue>) {
            state.push(action.payload);
        }
    },
});

export const { setQueues, addQueue } = queueSlice.actions;
export default queueSlice.reducer;

