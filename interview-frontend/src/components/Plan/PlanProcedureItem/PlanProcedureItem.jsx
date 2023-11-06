import React, { useState, useEffect } from "react";
import ReactSelect from "react-select";
import { useParams } from "react-router-dom";
import { addProcedureToPlan } from "../../../api/api";

const PlanProcedureItem = ({ procedure, users, preselectedUserId }) => {
    const [selectedUsers, setSelectedUsers] = useState(null);
    let { id } = useParams();    

    useEffect(() => {
        //debugger;
        if(preselectedUserId !== 0 && preselectedUserId !== "0" && preselectedUserId !== undefined && preselectedUserId !== null){
function selectItemsByValue(array, valuesToSelect) {
    const selectedItems = [];
    
    const values = valuesToSelect.split(',');

    for (const value of values) {
        const intValue = parseInt(value, 10);
        const selectedItem = array.find(item => item.value === intValue);

        if (selectedItem) {
            selectedItems.push(selectedItem);
        }
    }

    return selectedItems;
}

//const preselectedOption = users;
const valuesToSelect = preselectedUserId;

const selectedItems = selectItemsByValue(users, valuesToSelect);
// Set the selectedUser to the preselectedOption
console.log(selectedItems,'selectedItems')
setSelectedUsers(selectedItems);
        }
        
    }, [preselectedUserId, users]);

    const handleAssignUserToProcedure = async (e) => {
        //debugger;
        setSelectedUsers(e);
        // TODO: Remove console.log and add missing logic
        // console.log(e);
        for(let i = 0; i < e.length; i++) {
            //console.log(id,procedure.procedureId,e[i].value);
            await addProcedureToPlan(id,procedure.procedureId,e[i].value);
        }
    };

    return (
        <div className="py-2">
            <div>
                {procedure.procedureTitle}
            </div>

            <ReactSelect
                className="mt-2"
                placeholder="Select User to Assign"
                isMulti={true}
                options={users}
                value={selectedUsers}
                onChange={(e) => handleAssignUserToProcedure(e)}
            />
        </div>
    );
};

export default PlanProcedureItem;
