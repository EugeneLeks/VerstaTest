import { useEffect, useState} from 'react';
import './App.css';
function App() {

    const [orders, setOrders] = useState([]);
    
        useEffect(() => {
            const fetchData = async () => {
                let orders = await fetchOrders();
                setOrders(orders);
            }
            fetchData();
            setOrders(orders.map((order) => order.more = false));
        }, []);
    const [order, setOrder] = useState({
        recipientCity: "",
        recipientAddress: "",
        addresserCity: "",
        addresserAddress: "",
        cargoWeight: 0.0,
        receiveDate: "",
        more: true,
    });
    async function submit(e) {
        e.preventDefault();
        fetch("https://localhost:7178/Orders", {
            method: 'POST',
            accept: "text/plain",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(order)
            
        });
        let orders = await fetchOrders();
        setOrders(orders);
    }
    function handle(e) {
        const newOrder = { ...order }
        newOrder[e.target.id] = e.target.value
        setOrder(newOrder)
        console.log(newOrder)
    }
    async function fetchOrders() {
        const response = await fetch("https://localhost:7178/Orders");
        return response.json();
    }
    async function invertMore(order) {
        order.more = !order.more;
        console.log(order.more, order.id, "did");
        setOrder(order);
        
    }
    
    return <section>
        <div>
            <form onSubmit={(e)=>submit(e)}>
                <h3>Add order</h3>
                <input onChange={(e) => handle(e)} id="recipientCity" placeholder="Add recipient city" value={order.recipientCity}></input>
                <input onChange={(e) => handle(e)} placeholder="Add recipient address" id="recipientAddress" value={order.recipientAddress}></input>
                <input onChange={(e) => handle(e)} placeholder="Add addresser city" id="addresserCity" value={order.addresserCity}></input>
                <input onChange={(e) => handle(e)} placeholder="Add addresser address" id="addresserAddress" value={order.addresserAddress} ></input>
                <input onChange={(e) => handle(e)} placeholder="Add cargo weight" id="cargoWeight" value={order.cargoWeight}></input>
                <input onChange={(e) => handle(e)} placeholder="Add receive date" id="receiveDate" value={order.receiveDate} type="datetime-local"></input>
                <button>Create order</button>
            </form> 
        </div>
        <div>
        <div>Existing orders:</div>
            <ul>
                {orders.map((order) => (
                    <li key={order.id}>
                        <div className="order" >
                            Order Id: {order.id}
                            <button onClick={() => invertMore(order)}>Toggle more info</button>
                            {console.log(order.more, order.id, "did")}
                            {order.more && <ul>
                                <li>addresser city: {order.addresserCity}</li>
                                <li>addresser address: {order.addresserAddress}</li>
                                <li>recepient city: {order.recipientCity}</li>
                                <li>recepient address: {order.recipientAddress}</li>
                                <li>cargo weight: {order.cargoWeight}</li>
                                <li>receive date: {order.recieveDate}</li>
                            </ul>}
                        </div>
                    </li>
                ))}
                
                    
                
            </ul>
        </div>
    </section>
        
}



export default App;