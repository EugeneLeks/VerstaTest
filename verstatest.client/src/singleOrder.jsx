import {useState} from 'react';
function SingleOrder(order) {
    const [show, setShow] = useState(false);

    return <div onClick={() => setShow(!show)}>Order {order.id} {show && <ul >
        <li>addresser city: {order.addresserCity}</li>
        <li>addresser address: {order.addresserAddress}</li>
        <li>recepient city: {order.recipientCity}</li>
        <li>recepient address: {order.recipientAddress}</li>
        <li>cargo weight: {order.cargoWeight}</li>
        <li>receive date: {order.recieveDate}</li>
    </ul>}</div>
}   
export default SingleOrder