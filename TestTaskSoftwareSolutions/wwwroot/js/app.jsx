class MessageForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { phone: '', text: '', sender: '' };
        this.handlePhoneChange = this.handlePhoneChange.bind(this);
        this.handleTextChange = this.handleTextChange.bind(this);
        this.handleSenderNameChange = this.handleSenderNameChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handlePhoneChange(e) {
        this.setState({ phone: e.target.value });
    }

    handleTextChange(e) {
        this.setState({ text: e.target.value });
    }

    handleSenderNameChange(e) {
        this.setState({ sender: e.target.value });
    }

    handleSubmit(e) {
        e.preventDefault();
        const phone = this.state.phone.trim();
        const text = this.state.text.trim();
        const sender = this.state.sender.trim();

        if (!text || !phone) {
            return;
        }

        this.props.onMessageSubmit({ phone: phone, text: text, sender: sender });
        this.setState({ phone: '', text: '', sender: '' });
    }

    render() {
        return (
            <form className="MessageForm" onSubmit={this.handleSubmit}>
                <p>
                    <input
                    type="text"
                    placeholder="Sender phone"
                    value={this.state.phone}
                    onChange={this.handlePhoneChange}
                        />
                </p>

                <p>
                    <input
                       type="text"
                       placeholder="Message"
                       value={this.state.text}
                       onChange={this.handleTextChange}
                     />
                </p>

                <p>
                    <input
                        type="text"
                        placeholder="Sender name"
                        value={this.state.sender}
                        onChange={this.handleSenderNameChange}
                    />
                </p>

                <p>
                    <input type="submit" value="Send message" />
                </p>
            </form>
        );
    }
}

class MessageList extends React.Component {
    render() {
        return (
            <table border="1">
                <caption>List of sent messages</caption>
                <thead>
                    <tr>
                        <th>Sent date</th>
                        <th>Phone sender</th>
                        <th>Text</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.dataL.map(message =>
                        <tr>
                            <td>{message.sentDate}</td>
                            <td>{message.phone}</td>
                            <td>{message.text}</td>
                            <td>{message.status}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
}


class MessageBox extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
        this.handleMessageSubmit = this.handleMessageSubmit.bind(this);
    }

    loadMessageFromServer() {
        const xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = () => {
            const data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        };
        xhr.send();
    }

    handleMessageSubmit(message) {
        const data = new FormData();
        data.append('Phone', message.phone);
        data.append('Text', message.text);
        data.append('sender', message.sender);

        const xhr = new XMLHttpRequest();
        xhr.open('post', this.props.submitUrl, true);
        xhr.onload = () => this.loadMessageFromServer();
        xhr.send(data);
    }


    componentDidMount() {
        this.loadMessageFromServer();
        window.setInterval(
            () => this.loadMessageFromServer(),
            this.props.pollInterval,
        );
    }

    render() {
        return (
            <div >
                <h1>Messages</h1>
                <MessageForm onMessageSubmit={this.handleMessageSubmit} />
                <MessageList dataL={this.state.data} />
            </div>
            
        );
    }
}

ReactDOM.render(
    <MessageBox
        url="/message"
        submitUrl="/message/new"
        pollInterval={10000}
    />,
    document.getElementById('content'),
);