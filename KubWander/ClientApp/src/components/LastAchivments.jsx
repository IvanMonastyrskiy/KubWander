import './LastAchivments.css'

export default function LastAchivments() {

    return (
        <div className="last-achivment-container">
            <div className="last-achivment">
                <h2 className="achievement-title">��������� ����������</h2>
                <div className="columns-wrapper">
                    <div className="column left-column">
                        <div className="item">
                            <h3>���������</h3>
                            <p>�������� ������� ���������</p>
                        </div>
                        <div className="item">
                            <h3>��������� ����</h3>
                            <p>�������� �������� *** � ����������� ������������ �����</p>
                        </div>
                    </div>
                    <div className="column right-column">
                        <div className="item">
                            <h3>���������</h3>
                            <p>01.03.2023</p>
                        </div>
                        <div className="item">
                            <h3>��������� ����</h3>
                            <p>�������� �������� *** � ����������� ������������ �����</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
};
