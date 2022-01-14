import React from 'react';

//a = {
//    'name': "Product",
//    'price': "1000",
//    'description': "Product description",
//    'characteristics': {
//        'performance': '500',
//        'pressure': '180',
//        'engine': '4',
//        'size': '860*730*1300',
//        'weight': '420'
//    }
//}

function GetObjectPropValues(obj) {

    const listItems = Object.entries(obj).map(([key, value]) =>
        <tr key={key}>
            <td>
                {key}
            </td>
            <td>
                {value}
            </td>
        </tr>
    );
    return (
        <table class="AccordionContentTable">
            {listItems}
        </table>
    );

    //return (
    //    Object.entries(obj).map(([key, value]) => {
    //        return (
    //            <div>
    //                {key}
    //                {value}
    //            </div>
    //        );
    //    })
    //);
}

export default GetObjectPropValues;