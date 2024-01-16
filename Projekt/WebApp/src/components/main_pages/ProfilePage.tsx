import { getUser, setUser } from "../../User";
import { GetUser, GetMaxPostsForUser, GetPostsForUser, PutUser } from "../../Client";
import { useEffect, useState } from "react";
import Paginator from "../Paginator";

import PostList from "./PostList";
import UserProfile from "./UserProfile";
import { getPhrase } from "../LanguageSelector";

function ProfilePage() {
    const [posts, setPosts] = useState([]);
    const [maxPages, setMaxPages] = useState(1);
    const [page, setPage] = useState(1);

    const [editing, setEditing] = useState(false);
    const [bio, setBio] = useState('');

    const [locj, setLocj] = useState({} as any);

    var loc = getUser();
    
    useEffect(() => {
        setLocj(JSON.parse(loc ? loc : "{'userName': 'err', 'bio': 'err'}"));
        setBio(locj.bio);
    }, []);

    useEffect(() => {
        GetPostsForUser(locj.id, 1)
        .then((res) => {
            setPosts(res);
        }).catch((err) => {
            console.error(err);
            setPosts([]);
        });
    }, []);

    useEffect(() => {
        GetMaxPostsForUser(locj.id)
        .then((res) => { 
            setMaxPages(res);
        }).catch((err) => {
            console.error(err);
            setMaxPages(1);
        });
    }, []);

    const buttonHanlde = () => {
        if (editing){
            var newlocj = JSON.parse(JSON.stringify(locj));
            newlocj.bio = bio;
            PutUser(newlocj).then((res) => {
                console.log(res);
                setLocj(newlocj);
                setUser(newlocj);
                setBio(locj.bio);
            }).catch((err) => {
                console.error(err);
            });
        } 
        setEditing(!editing);
    }

    var bioedit = (
            <div className='bio-edit'> 
                <input className='bio-input' 
                    style={{'display' : editing ? 'block' : 'none'}} 
                    value={bio} 
                    onChange={(e) => setBio(e.target.value)}></input>
                <button className='btn btn-primary' onClick={buttonHanlde}>
                    {editing ? getPhrase('edit-bio') : getPhrase('save-bio')}
                </button>
            </div> );

    return (<>
        <div className="profile">
            <UserProfile user={locj} />
            {bioedit}
            <Paginator maxPages={maxPages} currentPage={page} setCurrentPage={setPage}/>
            
        </div>
    </>);
}

export default ProfilePage;